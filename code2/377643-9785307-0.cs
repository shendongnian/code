          {
            
            string[] arguments = Environment.GetCommandLineArgs();
            foreach (string argument in arguments)
         {
              
            if (argument.Split('=')[0].ToLower() == "/u")
               
         {
                    
            ThreadStart starter = delegate { WorkThreadFunction(argument.Split('=')[1]); };
            new Thread(starter).Start();
            Thread.Sleep(30000);
            Application.Exit();
            return;
         }
          }
