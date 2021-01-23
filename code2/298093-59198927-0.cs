        private void WatchFile()
        {
            try
            {
                fsw = new FileSystemWatcher(path, filter)
                {
                    EnableRaisingEvents = true
                };                
                fsw.Changed += Fsw_Changed;                
                fsw.Error += Fsw_Error;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void Fsw_Error(object sender, ErrorEventArgs e)
        {
            Thread.Sleep(1000);
            fsw.Changed -= Fsw_Changed;
            fsw.Error -= Fsw_Error;
            WatchFile();
        }
