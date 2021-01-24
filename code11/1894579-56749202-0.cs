    private static void RunExeWithParameter(string exePath, string parameter1, string parameter2)
    {
        string error = "";
        using (Process process = new Process())
        {
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = "\"" + exePath + "\"";
            process.StartInfo.Arguments = "\"" + parameter1 + " \"" + parameter2 + "\"";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();
            error = process.StandardError.ReadToEnd();
            process.Close();
        }
        if (error.Trim().Trim("\r\n".ToCharArray()).Trim() != "")
        {
            throw new Exception(error);
        }
    }
