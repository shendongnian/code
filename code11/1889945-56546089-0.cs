    public async Task<bool> CopyFiles(string destDir, List<MyFile> lstFiles)
    {
        try
        {
            int counter = 0;
            foreach (MyFile f in lstFiles)
            {
                f.jobStatus = "Copying";
                using (Stream source = File.Open(f.fullFileName))
                using (Stream destination = System.IO.File.Create(Path.Combine(destDir, f.fileName)))
                    await source.CopyToAsync(destination);
                f.jobStatus = "Finished";
                counter += 1;
                Console.WriteLine("M: " + DateTime.Now.ToString("hh:mm:ss") + "    " + counter);
                Messenger.Default.Send(counter, "MODEL");
            }
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }
