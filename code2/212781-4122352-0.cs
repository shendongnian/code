    public static string ExecuteCommand(string command) {
        ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + command)
            {
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        using (Process proc = new Process())
        {
            proc.StartInfo = procStartInfo;
            proc.Start();
            string output = proc.StandardOutput.ReadToEnd();
            if (string.IsNullOrEmpty(output))
                output = proc.StandardError.ReadToEnd();
            return output;
        }
    }
