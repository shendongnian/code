    using (Process process = new Process())
    {
        process.StartInfo.FileName = "C:\\temp\\bin\\fls.exe";
        process.StartInfo.Arguments = "-m C: -r C:\\temp\\image.dd > C:\\temp\\bin\\ntfs.bodyfile";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.RedirectStandardInput = true;
        process.StartInfo.RedirectStandardError = true;
        process.Start();
        using (System.IO.StreamReader reader = process.StandardOutput)
        {
            string sRes = reader.ReadToEnd();
            Console.WriteLine(sRes);
            reader.Close();
            process.WaitForExit();
        }
    }
