    private bool AmIRoot()
    {
       //Declarations:
       string fileName = "blah.txt",
              content = "";
       
       //Execute shell command:
       System.Diagnostics.Process proc = new System.Diagnostics.Process();
       proc.EnableRaisingEvents=false; 
       proc.StartInfo.FileName = "whoami > " + fileName;
       proc.StartInfo.Arguments = "";
       proc.Start();
       proc.WaitForExit();
    
       //View results of command execution:
       StreamReader sr = new StreamReader(fileName);
       content = sr.ReadLine();
       sr.Close();
       //Clean up magic file:
       File.Delete(fileName);
    
       //Return to caller:
       if(content == "root")
          return true;
       else
          return false;
    }
