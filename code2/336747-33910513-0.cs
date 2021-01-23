    process.Start();
    process.BeginOutputReadLine();
    process.BeginErrorReadLine();
    process.OutputDataReceived += (sender, args) =>
                                   {
                                        var outputData = args.Data;
                                        // ...
                                    };
    process.ErrorDataReceived += (sender, args) =>
                                {
                                    var errorData = args.Data;
                                    // ...
                                };
    process.WaitForExit();
