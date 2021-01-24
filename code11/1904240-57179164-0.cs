    class Program
    {
        static void Main(string[] args)
        {
            int ExitCode;
            try
            {
                var returnedMsgPath = string.Empty;
                if (LocateMsgExe(out returnedMsgPath))
                {
                    var startInfo = new ProcessStartInfo()
                    {
                        FileName = returnedMsgPath,
                        Arguments = @"* /v Hello",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true
                    };
                    var p = Process.Start(startInfo);
                    p.WaitForExit();
                    // *** Read the streams ***
                    string output = p.StandardOutput.ReadToEnd();
                    string error = p.StandardError.ReadToEnd();
                    ExitCode = p.ExitCode;
                    MessageBox.Show("output >>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
                    MessageBox.Show("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
                    MessageBox.Show("ExitCode: " + ExitCode.ToString(), "ExecuteCommand");
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static bool LocateMsgExe(out string returnedMsgPath)
        {
            returnedMsgPath = null;
            string[] msgPaths = new string[] { Environment.ExpandEnvironmentVariables(@"%windir%\system32\msg.exe"),
                                     Environment.ExpandEnvironmentVariables(@"%windir%\sysnative\msg.exe") };
            foreach (string msgPath in msgPaths)
            {
                if (File.Exists(msgPath))
                {
                    returnedMsgPath = msgPath;
                    return true;
                }
            }
            return false;
        }
    }
