    using System;
    using System.Diagnostics;
    
    public class Program
    {
        // make sure to call Process.Start from an STA thread
        [STAThread]
        static void Main(string[] args)
        {
            Process.Start(@"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Administrative Tools\IIS Manager.lnk");
        }
    }
