using (var proc = Process.GetProcessesByName(programName))
{
if (proc.Length == 1)
   {   
       Application.EnableVisualStyles();
       Application.SetCompatibleTextRenderingDefault(false);
       Application.Run(new Primary());
   }
   else
   {
       Application.Shutdown();
   }
}
Edited: you probably want to explicitly close the running instance if you're not going to create a window for it. I'm assuming this code is to prevent duplicate instances.
