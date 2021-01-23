        StreamWriter sw = new StreamWriter(sOutputFilePath);
        Process process = new Process();
        process.StartInfo.FileName = "ipconfig.exe";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.OutputDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            if (!String.IsNullOrEmpty(e.Data))
            {
                sw.WriteLine(e.Data);
            }
        });
        process.Start();
        process.BeginOutputReadLine();
        process.WaitForExit();
        sw.Close();
