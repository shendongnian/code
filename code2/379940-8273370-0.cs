      public delegate int CallbackToFindChildWindow(int hWnd, int lParam);
        
        private void AccessEditControlOfDialog()
        {
            IntPtr winHandle = IntPtr.Zero;
            winHandle = GetActiveWindow();
            const int NumberOfChars = 256;
            string dialogCaption = string.Empty;
            StringBuilder buff = new StringBuilder(NumberOfChars);
            ////Getting the caption of window..eg.  Open/Save/Save as
            if (GetWindowText((int)winHandle, buff, NumberOfChars) > 0)
            {
                dialogCaption = buff.ToString();
            }
            ////Getting the ClassName of the Dialog Window handle
            StringBuilder winClassName = new StringBuilder();
            int numChars = GetClassName((IntPtr)winHandle, winClassName, winClassName.Capacity);
           
            int targetControlWinHandle;
            CallbackToFindChildWindow myCallBack = new CallbackToFindChildWindow(this.EnumChildGetValue);
            ////Find the window handle by using its caption
            targetControlWinHandle = FindWindow(null, dialogCaption);
            if (targetControlWinHandle == 0)
            {
                Logger.Error("No handle value is found in the Common Doalog");
            }
            else
            {
                EnumChildWindows(targetControlWinHandle, myCallBack, 0);
            }
        }
        private int EnumChildGetValue(int handleWnd, int param)
        {
            StringBuilder controlWinClassName = new StringBuilder();
            ////Getting the ClassName of the Control Window handle
            int numChars = GetClassName((IntPtr)handleWnd, controlWinClassName, controlWinClassName.Capacity);
            if (controlWinClassName != null)
            {
                string text = "hi";
                ////For Normal Common Dialog box, the class name of Edit box is "Edit" which is for office 2007 "RichEdit20W"
                if ((!string.Equals(controlWinClassName.ToString().Trim(), ""))
                    && (controlWinClassName.ToString().Equals("Edit") || controlWinClassName.ToString().Equals("RichEdit20W")))
                {
                    if (controlWinClassName.ToString().Equals("Edit"))
                    {
                        
                        //// Set Text to the Edit box                  
                        SendMessage(handleWnd, WM_SETTEXT, text.Length, text);
                    }
                    else if (controlWinClassName.ToString().ToLower().Equals("richedit20w"))
                    {
                        SendMessage(handleWnd, WM_SETTEXT, 1, "");
                        ////Set the path to the RichEdit20W Which is specially for office 2007 and winxp                                                    
                        this.SetRichEditText((IntPtr)handleWnd, text);
                    }
                }
            }
        }
        
        private void SetRichEditText(IntPtr handleWnd, string text)
        {
            try
            {
                const uint WM_USER = 0x0400;
                SETTEXTEX setextex = new SETTEXTEX();
                setextex.codepage = 1200;
                setextex.flags = RTBW_FLAGS.RTBW_SELECTION;
                IntPtr ptr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(System.Runtime.InteropServices.Marshal.SizeOf(setextex.GetType()));
                System.Runtime.InteropServices.Marshal.StructureToPtr(setextex, ptr, true);
                IntPtr stringPtr = System.Runtime.InteropServices.Marshal.StringToBSTR(text);
                int result = SendMessage((int)handleWnd, (int)WM_USER + 97, ptr.ToInt32(), text);
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(ptr);
                System.Runtime.InteropServices.Marshal.FreeBSTR(stringPtr);
            }
            catch (Exception oEx)
            {
                Logger.Exception(oEx, "SetRichEditText");
                throw;
            }
        }
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, string lParam);
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, string lParam);
        [DllImport("User32.dll")]
        public static extern Int32 FindWindow(String lpClassName, String lpWindowName);
        [DllImport("User32.dll")]
        public static extern Boolean EnumChildWindows(int hWndParent, Delegate lpEnumFunc, int lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();
        [DllImport("User32.dll")]
        public static extern Int32 GetWindowText(int hWnd, StringBuilder s, int nMaxCount);
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, string lParam);
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, string lParam);
        public const Int32 WM_SETTEXT = 0x000C;
        [StructLayout(LayoutKind.Sequential)]
        public struct SETTEXTEX
        {
            public ABC.FileSystemBrowser.CustomView.CommonEnum.RTBW_FLAGS flags;
            public long codepage;
        }
        public enum RTBW_FLAGS
        {
            RTBW_DEFAULT = 0,
            RTBW_KEEPUNDO = 1,
            RTBW_SELECTION = 2
        }
