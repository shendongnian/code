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
    }
