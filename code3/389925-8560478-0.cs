    using System.Diagnostics;
    
    class Test
    {
        static void Main()
        {
            using (Process p = Process.Start("notepad.exe"))
            {
                p.CloseMainWindow();
                p.Close();
            }
        }
    }
