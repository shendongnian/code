            try
            {
                using (Process myProcess = new Process())
                {
                    myProcess.StartInfo.FileName = <Your program collection object>.InstallPath;
                    myProcess.Start();
                    <Your program collection object>.InstallProcessID = myProcess.Id;
                    myProcess.WaitForExit();
                    // Any follow up code after install has completed.
                }
            }
            catch (Exception ex)
            {
                // Error message that uses ex
            }
