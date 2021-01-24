        private async void CopyFile()
        {
            var fh = new FileHelper();
            bool result = await fh.CopyFilesAsync(@"C:\Test\Destination\", fileList.ToList());
            if (result)
                Messenger.Default.Send("Files copying finished", "VM");
            else
                Messenger.Default.Send("Files copying failed", "VM");
        }
        public async Task<bool> CopyFilesAsync(string destDir, List<MyFile> lstFiles)
        {
            try
            {
                int counter = 0;
                await Task.Run(() =>
                {
                    foreach (MyFile f in lstFiles)
                    {
                        f.jobStatus = "Copying";
                        Thread.Sleep(500);
                        File.Copy(f.fullFileName, Path.Combine(destDir, f.fileName), true);
                        f.jobStatus = "Finished";
                        counter += 1;
                        Messenger.Default.Send(counter, "MODEL");
                        Thread.Sleep(500);
                    }
                });
                
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }
