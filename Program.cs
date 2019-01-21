using System;
using System.IO;

namespace LS
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

             if (args.Length > 0 && args[0] == "-s")
             {
                foreach (DirectoryInfo d in dir.GetDirectories())
                {
                    Console.WriteLine($"\t{d.Name}");
                    Console.WriteLine("---------------------------------------------------------------------------------------------");
                }

                foreach (FileInfo fil in dir.GetFiles())
                {
                    if (fil.Length > 1e+9)
                    {
                        double resultGB = fil.Length / 1e+9;
                        WriteFileSizeAndNameToOutput(fil.Name, resultGB, "GB");
                    }
                    else if (fil.Length > 1000000)
                    {
                        double resultMB = fil.Length / 1000000;
                        WriteFileSizeAndNameToOutput(fil.Name, resultMB, "MB");
                     
                    }
                    else if (fil.Length > 1000)
                    {
                        double resultKB = fil.Length / 1000;
                        WriteFileSizeAndNameToOutput(fil.Name, resultKB, "KB");
                    }
                    else if (fil.Length < 1000)
                    {
                        double result = fil.Length;
                        WriteFileSizeAndNameToOutput(fil.Name, result, "B");
                    }
                    Console.WriteLine("---------------------------------------------------------------------------------------------");
                }

             }
 

            Console.ReadKey();
        }

        private static void WriteFileSizeAndNameToOutput(string fileName, double fileSize, string unit)
        {
            Console.WriteLine($"\t{fileSize}\t{unit}\t{fileName}");
        }
    }
}
