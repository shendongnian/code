using (Process process = new Process())
        {
            process.StartInfo.FileName = "ipconfig.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            // Synchronously read the standard output of the spawned process. 
            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();
            // Write the redirected output to this application's window.
            Console.WriteLine(output);
            process.WaitForExit();
        }
You can split the output lines with space(s) and get the needed value
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.standardoutput?view=netframework-4.8
