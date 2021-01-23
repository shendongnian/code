    static void CallProcess(string[] args)
            {
                Process prc= new Process();
    
                pro.StartInfo.FileName   = "exe path";
                pro.StartInfo.Arguments = args;
    
                pro.Start();
            }
