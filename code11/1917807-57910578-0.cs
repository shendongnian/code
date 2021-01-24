            private void Test()
            {
                // Setup all paths before initializing Python engine
                string pathToPython = @"C:\Users\user\AppData\Local\Programs\Python\Python37-32";
                string path = pathToPython + ";" +
                              Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Machine);
                Environment.SetEnvironmentVariable("PATH", path, EnvironmentVariableTarget.Process);
                Environment.SetEnvironmentVariable("PYTHONHOME", pathToPython, EnvironmentVariableTarget.Process);
                var lib = new[]
                {
                    @"C:\Users\user\source\path\repos\SamplePy\SamplePy2",
                    Path.Combine(pathToPython, "Lib"),
                    Path.Combine(pathToPython, "DLLs")
                };
                string paths = string.Join(";", lib);
                Environment.SetEnvironmentVariable("PYTHONPATH", paths, EnvironmentVariableTarget.Process);
                
                using (Py.GIL()) //Initialize the Python engine and acquire the interpreter lock
                {
                    try
                    {
                        // import your script into the process
                        dynamic sampleModule = Py.Import("SamplePy");
                        // It is more maintainable to communicate with the script with
                        // function parameters and return values, than using argv 
                        // and input/output streams.
                                               
                        int x = 3;
                        int y = 4;
                        dynamic results = sampleModule.sample_func(x, y);
                        Console.WriteLine("Results: " + results);
                    }
                    catch (PythonException error)
                    {
                        // Communicate errors with exceptions from within python script -
                        // this works very nice with pythonnet.
                        Console.WriteLine("Error occured: ", error.Message);
                    }
                }
            }
