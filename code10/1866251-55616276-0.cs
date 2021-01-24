        static readonly string OnScreenKeyboardProgramName = "osk";
        public static void StartOnScreenKeyboard()
        {
            System.Diagnostics.Process.Start(OnScreenKeyboardProgramName);
        }
        public static void StopOnScreenKeyboard()
        {
            System.Diagnostics.Process[] processes = 
                System.Diagnostics.Process.GetProcessesByName(OnScreenKeyboardProgramName);
            if (processes.Length > 0)
            {
                processes[0].Kill();
                processes[0].WaitForExit();
                processes[0].Dispose();
            }
        }
