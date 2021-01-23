    using System;
    using System.Diagnostics;
    using System.IO;
    
    class Program {
        static void Main(string[] args) {
            ShowOpenWithDialog(@"c:\temp\test.txt");
        }
        public static void ShowOpenWithDialog(string path) {
            var args = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll");
            args += ",OpenAs_RunDLL " + path;
            Process.Start("rundll32.exe", args);
        }
    }
