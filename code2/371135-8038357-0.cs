       public static string ExecuteCmd(string arguments)
        {
            // Create the Process Info object with the overloaded constructor
            // This takes in two parameters, the program to start and the
            // command line arguments.
            // The arguments parm is prefixed with "@" to eliminate the need
            // to escape special characters (i.e. backslashes) in the
            // arguments string and has "/C" prior to the command to tell
            // the process to execute the command quickly without feedback.
            ProcessStartInfo _info =
                new ProcessStartInfo("cmd", @"/C " + arguments);
            // The following commands are needed to redirect the
            // standard output.  This means that it will be redirected
            // to the Process.StandardOutput StreamReader.
            _info.RedirectStandardOutput = true;
            // Set UseShellExecute to false.  This tells the process to run
            // as a child of the invoking program, instead of on its own.
            // This allows us to intercept and redirect the standard output.
            _info.UseShellExecute = false;
            // Set CreateNoWindow to true, to supress the creation of
            // a new window
            _info.CreateNoWindow = true;
            // Create a process, assign its ProcessStartInfo and start it
            Process _p = new Process();
            _p.StartInfo = _info;
            _p.Start();
            // Capture the results in a string
            string _processResults = _p.StandardOutput.ReadToEnd();
            // Close the process to release system resources
            _p.Close();
            // Return the output stream to the caller
            return _processResults;
        }
