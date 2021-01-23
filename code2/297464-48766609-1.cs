    try
    {
    File.Copy(somefile)
    }
    catch (IOException e)
    {
     if (e.Message.Contains("in use"))
                            {
                               
                                Process.StartInfo.UseShellExecute = false;
                                Process.StartInfo.RedirectStandardOutput = true;                           
                                Process.StartInfo.FileName = "cmd.exe";
                                Process.StartInfo.Arguments = "/C copy \"" + yourlockedfile + "\" \"" + destination + "\"";
                                Process.Start();                            
                                Console.WriteLine(Process.StandardOutput.ReadToEnd());
                                Proess.WaitForExit();
                                Process.Close();                          
                            }
    }
    
    the try/catch should be added on top of your current try/catch to handle the file in use exception to allow your code to continue... 
