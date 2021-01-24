using (var proc = Process.GetProcessesByName(programName))
{
if (proc.Length == 1)
   {   
       Application.EnableVisualStyles();
       Application.SetCompatibleTextRenderingDefault(false);
       Application.Run(new Primary());
   }
}
