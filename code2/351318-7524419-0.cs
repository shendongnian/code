            var process = new Process();
            process.StartInfo = new ProcessStartInfo("notepad.exe");
            process.EnableRaisingEvents = true;
            process.Exited += (o, e) =>
                                  {
                                      Console.WriteLine("Closed");
                                  };
            process.Start();
