c#
        public static void StartProcessAndWait(string processFile, string arguments, string workingDirectory)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = processFile,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    WorkingDirectory = workingDirectory
                }
            };
            proc.Start();
            var _ = ConsumeReader(proc.StandardOutput);
            // ReSharper disable once RedundantAssignment
            _ = ConsumeReader(proc.StandardError);
            
            async Task ConsumeReader(TextReader reader)
            {
                string text;
                while ((text = await reader.ReadLineAsync()) != null)
                    Console.WriteLine(text);
            }
            proc.WaitForExit(30000);
        }
