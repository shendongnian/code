    using System;
    using SevenZipExtractor; // https://github.com/adoconnection/SevenZipExtractor
    using ByteSizeLib; // https://github.com/omar/ByteSize
    
    namespace ConsoleAppSevenZipExtractor
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (ArchiveFile archiveFile = new ArchiveFile(@"C:\test.7z"))
                {
                    foreach (var entry in archiveFile.Entries)
                    {
                        Console.WriteLine($"{entry.FileName} with {ByteSize.FromBytes(entry.Size)}");
    
                        // extract to file to current path
                        entry.Extract(entry.FileName);
                    }
                }
    
                Console.ReadKey();
            }
        }
    }
