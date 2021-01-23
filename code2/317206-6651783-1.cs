        private bool LaunchApp(String sAppPath, String sArg)
        {
            bool bSuccess = false;
            try
            {
                //create a new process
                Process myApp = new Process();
                myApp.StartInfo.FileName = sAppPath;
                myApp.StartInfo.Arguments = sArg;
                bSuccess = myApp.Start();
            }
            catch (Win32Exception e)
            {
                MessageBox.Show("Error Details: {0}", e.Message);
            }
            return bSuccess;
        }
