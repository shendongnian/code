    using System.Runtime.InteropServices;
    // Get a handle to an application window.
            [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
            public static extern IntPtr FindWindow(string lpClassName,
                string lpWindowName);
    
            // Activate an application window.
            [DllImport("USER32.DLL")]
            public static extern bool SetForegroundWindow(IntPtr hWnd);
    
            private void test()
            {
                IntPtr calculatorHandle = FindWindow("CalcFrame", "Calculator");
    
                // Verify that Calculator is a running process.
                if (calculatorHandle == IntPtr.Zero)
                {
                    MessageBox.Show("Calculator is not running.");
                    return;
                }
    
                // Make Calculator the foreground application and send it 
                // a set of calculations.
                SetForegroundWindow(calculatorHandle);
                SendKeys.SendWait("111");
                SendKeys.SendWait("*");
                SendKeys.SendWait("11");
                SendKeys.SendWait("=");
                
            }
