`
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
namespace zipStream
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var file = File.OpenRead(@"YOUR-REMOTE-FILE-NAME");
            ZipArchive ar = new ZipArchive(file, ZipArchiveMode.Read);
            foreach (ZipArchiveEntry entry in ar.Entries)
            {
                using (Stream stream = entry.Open())
                {
                    try
                    {
                        Byte[] inArray = new Byte[(int)entry.Length];
                        Char[] outArray = new Char[(int)((entry.Length + 10) * 2)];
                        stream.Read(inArray, 0, (int)entry.Length);
                        Convert.ToBase64CharArray(inArray, 0, inArray.Length, outArray, 0);
                        Console.WriteLine($"Processed {entry.Name}");
                    }
                    catch (Exception e)
                    {
                        var msg = e.Message;
                        Console.WriteLine($"Failed to process {entry.Name}");
                        System.Diagnostics.Debugger.Break();
                    }
                }
                // at this point you have your file content in outArray variable
                // you can find some guidance on writing blobs to a db here:
                // https://www.c-sharpcorner.com/uploadfile/Ashush/working-with-binary-large-objects-blobs/
            }
        }
    }
}
`
