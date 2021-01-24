   if (Process.GetProcessesByName(programName).Length == 1)
   {   
       Application.EnableVisualStyles();
       Application.SetCompatibleTextRenderingDefault(false);
       Application.Run(new Primary());
   }
   else
   {
       Application.Shutdown();
   }
Edited: fixed reasoning and solution
