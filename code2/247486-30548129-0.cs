    /// <summary>
    /// For MONO ssl decryption failed
    /// </summary>
    public static string PostString(string url, string data)
    {
        Process p = null;
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = "curl",
                Arguments = string.Format("-k {0} --data \"{1}\"", url, data),
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = false,
            };
            p = Process.Start(psi);
            return p.StandardOutput.ReadToEnd();
        }
        finally
        {
            if (p != null && p.HasExited == false)
                p.Kill();
        }
    }
