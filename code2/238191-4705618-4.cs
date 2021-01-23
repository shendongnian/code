    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
    
            [DllImport("user32.dll")]
            static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
    
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                int maxWaitTime = 15000;
    
                int tc = System.Environment.TickCount;
    
                while (true)
                {
                    System.Threading.Thread.Sleep(1000);
    
                    if (System.Environment.TickCount - tc > maxWaitTime)
                    {
                        break;
                    }
    
                    if (GetAsyncKeyState(Keys.Escape) > 0)
                    {
                        break;
                    }
                }
    
                Application.Run(new Form1());
            }
        }
    }
