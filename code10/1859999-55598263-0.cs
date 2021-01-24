    using System;
    using System.IO;
    
    
    namespace VSU1vFileCopy
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string Src_FOLDER = @"C:\Data";
                const string Dest_FOLDER = @"E:\Data";
                string[] originalFiles = Directory.GetFiles(Src_FOLDER, "*", SearchOption.AllDirectories);
    
                Array.ForEach(originalFiles, (originalFileLocation) =>
                {
                    FileInfo originalFile = new FileInfo(originalFileLocation);
                    FileInfo destFile = new FileInfo(originalFileLocation.Replace(Src_FOLDER, Dest_FOLDER));
    
                    if (destFile.Exists)
                    {
                        if (originalFile.Length > destFile.Length)
                        {
                            originalFile.CopyTo(destFile.FullName, true);
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(destFile.DirectoryName);
                        originalFile.CopyTo(destFile.FullName, false);
                    }
                });
            }
        }
    }
