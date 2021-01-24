c#
    procStartInfo.RedirectStandardOutput = true;
    procStartInfo.UseShellExecute = false;
    procStartInfo.CreateNoWindow = true;
    procStartInfo.RedirectStandardError = true; // <--- Add this line
    using (Process process = new Process())
    {
        process.StartInfo = procStartInfo;
        process.Start();
        process.WaitForExit();
        // ---> I would add this here...
        var result = process.StandardOutput.ReadToEnd();
        string err = process.StandardError.ReadToEnd(); // <-- Capture errors
        if (!string.IsNullOrEmpty(err))
        {
           Console.WriteLine(err); // <---- Print any errors for troubleshooting
        }
        Console.WriteLine(result);
        // ----------------        
      }
