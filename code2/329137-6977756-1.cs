    private static void Delete(System.IO.FileInfo file)
        {
            if (file.Exists)
            {
                int Attempt = 0;
                bool ShouldStop = false;
                while (!ShouldStop)
                {
                    if (CanDelete(file))
                    {
                        file.Delete();
                        ShouldStop = true;
                    }
                    else if (Attempt >= 3)
                    {
                        ShouldStop = true;
                    }
                    else
                    {
                        // wait one sec
                        System.Threading.Thread.Sleep(1000);
                    }
                    
                    Attempt++;
                }
            }
        }
        
        private static bool CanDelete(System.IO.FileInfo file)
        {
            try
            {
                //Just opening the file as open/create
                using (FileStream fs = new FileStream(file.FullName, FileMode.OpenOrCreate))
                {
                    //If required we can check for read/write by using fs.CanRead or fs.CanWrite
                }
                return false;
            }
            catch (IOException ex)
            {
                //check if message is for a File IO
                string __message = ex.Message.ToString();
                if (__message.Contains("The process cannot access the file"))
                    return true;
                else
                    throw;
            }
        }
