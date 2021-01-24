    public async Task<int> RunProcessAsync(string params[])
        {
            try
            {
                var tcs = new TaskCompletionSource<int>();
        
                var process = new Process
                {
                    StartInfo = {
                        FileName = 'file path',
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        Arguments = "shell command",
                        UseShellExecute = false,
                        CreateNoWindow = true
                    },
                    EnableRaisingEvents = true
                };
                
        
                process.Exited += (sender, args) =>
                {
                    tcs.SetResult(process.ExitCode);
                    process.Dispose();
                };
        
                process.Start();
                // Use asynchronous read operations on at least one of the streams.
                // Reading both streams synchronously would generate another deadlock.
                process.BeginOutputReadLine();
                string tmpErrorOut = await process.StandardError.ReadToEndAsync();
                //process.WaitForExit();
        
        
                return await tcs.Task;
            }
            catch (Exception ee) {
                Console.WriteLine(ee.Message);
            }
            return -1;
        }
