    public class ConsoleAppWrapper
    {
        private Process _process;
        public ConsoleAppWrapper(string exeFilename)
        {
            // Start the Player console app up with hooks to standard input/output and error output
            _process = new Process()
            {
                StartInfo = new ProcessStartInfo(exeFilename)
                {
                    UseShellExecute = false,
                    
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true
                }
            };
            _process.Start();
        }
        public StreamReader StandardOutput => _process.StandardOutput;
        public StreamReader StandardError => _process.StandardError;
        public StreamWriter StandardInput => _process.StandardInput;
        ~ConsoleAppWrapper()
        {
            // When I used this class to help with some SpecFlow feature tests of a console app I found it wasn't destroying the console window correctly when assertions failed
            // using a destructor ensures the windows is destroyed when the wrapper goes out of scope.
            Kill();
        }
        public void Kill()
        {
            Dispose();
        }
    }
