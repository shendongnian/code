    static void CallProcess(string[] args)
            {
                // create a new process
                Process pro= new Process();
    
                pro.StartInfo.FileName   = "exe path";
                pro.StartInfo.Arguments = args;
    
                pro.Start();
            }
