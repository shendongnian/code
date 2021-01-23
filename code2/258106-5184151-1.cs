        [STAThread]
        static void Main(string[] args)
        {
            System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
            myProcess.StartInfo.FileName = "calc";
            myProcess.Start();
            IntPtr hWnd = myProcess.Handle;
            SetFocus(new HandleRef(null, hWnd));
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr SetFocus(HandleRef hWnd);
