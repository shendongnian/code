    static bool IsArchive(string filename)
    {
        string _7z = @"C:\Program Files\7-Zip\7z.exe";
    
        bool result = false;
        using (Process p = new Process())
        {
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = _7z;
            p.StartInfo.Arguments = $"l \"{filename}\"";
            p.Start();
            string stdout = p.StandardOutput.ReadToEnd();
            string stderr = p.StandardError.ReadToEnd();
    
            if (stdout.Contains("Type = "))
            {
                result = true;
            }
    
            p.WaitForExit();
        }
    
        return result;
    }
