     public static void WriteLine(string text)
            {
                bool success = false;
                while (!success)
                {
    
                    try
                    {
                        using (var fs = new FileStream(Filename, FileMode.Append))
                        {
                            // todo: write to stream here
    
                            success = true;
                        }
                    }
                    catch (IOException)
                    {
                        int errno = Marshal.GetLastWin32Error();
                        if(errno != 32) // ERROR_SHARING_VIOLATION
                        {
                            // we only want to handle the 
                            // "The process cannot access the file because it is being used by another process"
                            // exception and try again, all other exceptions should not be caught here
                            throw;
                        }
                    Thread.Sleep(100);
                    }
                }
    
            }
