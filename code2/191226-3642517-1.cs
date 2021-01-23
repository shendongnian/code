    process.StartInfo.CreateNoWindow = true;
    process.StartInfo.UseShellExecute = false;
    process.StartInfo.RedirectStandardOutput = true;
    process.OutputDataReceived += (sender, args) => Console.WriteLine(args.Data);
    process.Start();
    process.BeginOutputReadLine();
    process.WaitForExit();
