    protected override void OnStart(string[] args)
    {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            
            /*
            This is commented out so we can see what the script is doing
            inside the cmd console.
            */
            //p.StartInfo.RedirectStandardOutput = true;
            
            p.StartInfo.FileName = "C:\\myFile.bat";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            
            /*
            Since we aren't redirecting the output, we have to comment out
            this line or we get an error
            */
            //string output = p.StandardOutput.ReadToEnd();
            
            p.WaitForExit();
    }
