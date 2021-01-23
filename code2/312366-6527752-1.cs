    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace YourApp
    {
        class Program
        {
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool SetForegroundWindow(IntPtr hWnd);
    
            [STAThread]
            static void Main()
            {
                bool createdNew = true;
                using (Mutex mutex = new Mutex(true, "MyApplicationName", out createdNew))
                {
                    if (createdNew)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Form1 frm = new Form1();
                        frm.SetNewData("send command line here");
                        Application.Run(frm);
                    }
                    else
                    {
                        Process current = Process.GetCurrentProcess();
                        foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                        {
                            if (process.Id != current.Id)
                            {
                                SetForegroundWindow(process.MainWindowHandle);
                                // send message to that form or use .Net remoting
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
