string[] allLines;
using (Process process = new Process())
        {
            process.StartInfo.FileName = "ipconfig.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            // Synchronously read the standard output of the spawned process. 
            StreamReader reader = process.StandardOutput;
            string output = reader.ReadToEnd();
            // Convert all text to string array
            allLines = output.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            // Write the redirected output to this application's window.
            Console.WriteLine(output);
            process.WaitForExit();
        }
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.standardoutput?view=netframework-4.8
