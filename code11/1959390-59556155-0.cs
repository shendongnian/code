        public class SearchData{
            public string Title;
            public IntPtr hWnd;
        }
        private delegate bool EnumWindowsProc(IntPtr hWnd, ref SearchData data);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, ref SearchData data);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy,  int wFlags);
        private void test(){
            IntPtr hwnd = SearchForWindow("Discord");
            SetWindowPos(hwnd, 0, 50, 175, 1000, 750, 0x0040);
        }
        public IntPtr SearchForWindow(string title){
            SearchData sd = new SearchData { Title = title };
            EnumWindows(new EnumWindowsProc(EnumProc), ref sd);
            return sd.hWnd;
        }
        public bool EnumProc(IntPtr hWnd, ref SearchData data){
            StringBuilder sb = new StringBuilder(1024);
            GetWindowText(hWnd, sb, sb.Capacity);
            if (sb.ToString().Contains(data.Title)){
                data.hWnd = hWnd;
                return false;
            }
            else return true;
        }
Also @Jimi I tried your approach but I could not work with it because it could not find Automation in the System.Windows namespace
