            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.FileName = <Your program collection object>.installPath ;
                    myProcess.Start();
                    myProcess.WaitForExit();
                    // Any follow up code after install has completed.
                }
            }
            catch (Exception ex)
            {
                // Error message that uses ex
            }
        
