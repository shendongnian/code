    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Threading;
    
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            private static System.Threading.Timer _timer;
            private static ManualResetEvent _signal;
    
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                _signal = new ManualResetEvent(false);
    
                _timer = new System.Threading.Timer(Timer_Signaled, null, 15000, 0);
    
                _signal.WaitOne();
                _signal.Reset();
    
                Application.Run(new Form1());
            }
    
            private static void Timer_Signaled(object state)
            {
                _signal.Set();
            }
        }
    }
