        public delegate void EmptyHandler();
        public static void SafeCall(this Control control, EmptyHandler method) 
        {
            if (control.InvokeRequired)
            {
                control.Invoke(method);
            }
            else
            {
                method();
            }
        } 
