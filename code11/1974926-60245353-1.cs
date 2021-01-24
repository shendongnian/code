using (Process myProcess = new Process())
{
   ProcessStartInfo myProcessStartInfo = new ProcessStartInfo("notepad.exe");
   myProcess.StartInfo = myProcessStartInfo;
   myProcess.Start();
   System.Threading.Thread.Sleep(1000);
   ProcessModule myProcessModule;
   
   Console.WriteLine("Base addresses of the modules associated "+"with 'notepad' are:");
   for (int i = 0; i < myProcess.Modules.Count; i++)
   {
      myProcessModule = myProcess.Modules[i];
      Console.WriteLine(myProcessModule.ModuleName + " : " + (IntPtr)myProcessModule.BaseAddress);
   }
   Console.WriteLine("The process's main module's base address is: 0x"+myProcess.MainModule.BaseAddress.ToString("x8"));
   myProcess.CloseMainWindow();
}
