//Launching excel.exe with /safe as arg
var excelExample1 = @"""C:\Program Files (x86)\Microsoft Office\Office15\EXCEL.EXE"" /safe";
LaunchCMD.Invoke(excelExample1);
//To get its output, if any
var getOutput = LaunchCMD.Output;
 **LaunchCMD Helper Class**
    class LaunchCMD
    {
        public static string Output
        {
            get; set;
        } = "";
        public static void Invoke(string command, bool waitTillExit = false, bool closeOutputWindow = false)
        {
            ProcessStartInfo ProcessInfo;
            Process Process = new Process();
            ProcessInfo = new ProcessStartInfo("cmd.exe", "/C " + command);
            ProcessInfo.CreateNoWindow = false;
            ProcessInfo.UseShellExecute = false;
            ProcessInfo.RedirectStandardOutput = true;
            ProcessInfo.RedirectStandardError = true;
            Process.EnableRaisingEvents = true;
            Process = Process.Start(ProcessInfo);
            Process.ErrorDataReceived += ConsoleDataReceived;
            Process.OutputDataReceived += ConsoleDataReceived;
            Process.BeginOutputReadLine();
            Process.BeginErrorReadLine();
            if (waitTillExit == true)
            {
                Process.WaitForExit();
            }
            if (closeOutputWindow == true)
            {
                Process.CloseMainWindow();
            }
            Process.Close();
            System.Threading.Thread.Sleep(1000);
            Output.ToString();
        }
        private static void ConsoleDataReceived(object sender, DataReceivedEventArgs e)
        {
            System.Threading.Thread.Sleep(1000);
            if (e.Data != null)
            {
                Output = Output + e.Data;
            }
        }
    }
