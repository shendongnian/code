    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    internal class Zone
    {
        public static void WriteAlternateStream(string path, string text)
        {
            const int GENERIC_WRITE = 1073741824;
            const int FILE_SHARE_WRITE = 2;
            const int OPEN_ALWAYS = 4;
            var stream = CreateFileW(path, GENERIC_WRITE, FILE_SHARE_WRITE, IntPtr.Zero, OPEN_ALWAYS, 0, IntPtr.Zero);
            using (FileStream fs = new FileStream(stream, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(text);
                }
            }
        }
        public static void Id()
        {
            var x = Application.ExecutablePath + ":Zone.Identifier";
            WriteAlternateStream(x, "[ZoneTransfer]\r\nZoneId=3");
        }
        # region Imports
        [DllImport("kernel32.dll", EntryPoint = "CreateFileW")]
        public static extern System.IntPtr CreateFileW(
            [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPWStr)] string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            [InAttribute()] IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            [InAttribute()] IntPtr hTemplateFile
        );
        #endregion
    }
