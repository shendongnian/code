        var process = new Process
                          {
                              StartInfo = new ProcessStartInfo
                                              {
                                                  FileName = "test.exe",
                                                  Arguments = "-F input.txt",
                                              }
                          };
        process.Start();
        process.WaitForExit();
