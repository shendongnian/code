    var psi = new ProcessStartInfo
              {
                  FileName = "cscript",
                  RedirectStandardError = true,
                  RedirectStandardOutput = true,
                  RedirectStandardInput = true,
                  UseShellExecute = false,
                  //CreateNoWindow = true,
                  WindowStyle = ProcessWindowStyle.Normal,
                  Arguments = "//nologo ask_SO.vbs"
              };
    var process = Process.Start(psi);
    process.BeginOutputReadLine();
    var buffer = new StringBuilder();
    process.OutputDataReceived += (s, args) =>
    {
        buffer.AppendLine(args.Data);
    };
    foreach (var line in textBox1.Lines)
    {
        buffer.AppendLine(line);
        process.StandardInput.WriteLine(line);
        
        Thread.Sleep(50);
    }
    process.StandardInput.Flush();
    process.StandardInput.Close();
    process.WaitForExit();
    output.Text = buffer.ToString();
