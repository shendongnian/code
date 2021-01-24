    class Copy
    {
        public void CopyFunction(string sourcePath, string destinationPath)
        {
            byte[] buffer = new byte[1024 * 10]; // 10K buffer, you can change to larger size.
            using (var progress = new ProgressBar())
            using (FileStream source = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
            {
                long fileLength = source.Length;
                using (FileStream dest = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                {
                    long totalBytes = 0;
                    int currentBlockSize = 0;
                    while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        totalBytes += currentBlockSize;
                        dest.Write(buffer, 0, currentBlockSize);
                        progress.Report((double)totalBytes / fileLength);
                    }
                    progress.Report((double)1.0);
                }
                //File.Copy(sourceFile, destinationFile);
                //Console.Write("Files are being copied... ");
                //using (var progress = new ProgressBar())
                //{
                //    for (int i = 0; i <= 100; i++)
                //    {
                //        progress.Report((double)i / 100);
                //        Thread.Sleep(20);
                //    }
                //}
                Console.WriteLine("File Copied");
            }
        }
    }
