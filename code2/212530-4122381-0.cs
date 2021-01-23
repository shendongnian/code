        private static void RunCommand(string command)
        {
            var process = new Process()
                              {
                                  StartInfo = new ProcessStartInfo("cmd")
                                                  {
                                                      UseShellExecute = false,
                                                      RedirectStandardInput = true,
                                                      RedirectStandardOutput = true,
                                                      CreateNoWindow = true,
                                                      Arguments = "/c " + command,
                                                  }
                              };
            process.OutputDataReceived += (s, e) => Console.WriteLine(e.Data);
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
        }
