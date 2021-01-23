    Process test = new Process();
    test.StartInfo = psi;
    test.EnableRaisingEvents = true;
    test.Exited += new EventHandler(test_Exited);
    
    ...    
    
    void test_Exited(object sender, EventArgs e)
    {
      int exitCode = ((Process)sender).ExitCode;
      switch (exitCode)
      {
         case 0:
             DoSomething();
             break;
         case 1:
             .......
      }
  
