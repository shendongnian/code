     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            KeyboardHook kh;
            bool b=true;
            private void Form1_Load(object sender, EventArgs e)
            {
                kh = new KeyboardHook();
    
                kh.SetHook();
    
                kh.OnKeyDownEvent += kh_OnKeyDownEvent;
             
            }
    
            void kh_OnKeyDownEvent(object sender, KeyEventArgs e)
            {
    
                if (e.KeyData == (Keys.F10) && !b) { this.Show(); }
                if (e.KeyData == (Keys.F10 ) && b) { this.Hide(); }
                b=!b;
    
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                kh.UnHook();
            }
        }
        public class Win32Api
    
        {
    
            #region 
    
            public const int WM_KEYDOWN = 0x100;
    
            public const int WM_KEYUP = 0x101;
    
            public const int WM_SYSKEYDOWN = 0x104;
    
            public const int WM_SYSKEYUP = 0x105;
    
            public const int WH_KEYBOARD_LL = 13;
    
    
    
            [StructLayout(LayoutKind.Sequential)] 
    
            public class KeyboardHookStruct
    
            {
    
                public int vkCode; 
    
                public int scanCode; 
    
                public int flags;
    
                public int time;
    
                public int dwExtraInfo;
    
            }
    
            #endregion
    
            #region Api
    
            public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);
    
         
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    
            public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
    
    
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    
            public static extern bool UnhookWindowsHookEx(int idHook);
    
          
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    
            public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);
    
            [DllImport("user32")]
    
            public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);
    
            [DllImport("user32")]
    
            public static extern int GetKeyboardState(byte[] pbKeyState);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
    
            public static extern IntPtr GetModuleHandle(string lpModuleName);
    
            #endregion
        }
        public class KeyboardHook
    
        {
    
            int hHook;
    
            Win32Api.HookProc KeyboardHookDelegate;
    
            public event KeyEventHandler OnKeyDownEvent;
    
            public event KeyEventHandler OnKeyUpEvent;
    
            public event KeyPressEventHandler OnKeyPressEvent;
    
            public KeyboardHook() { }
    
            public void SetHook()
    
            {
    
                KeyboardHookDelegate = new Win32Api.HookProc(KeyboardHookProc);
    
                Process cProcess = Process.GetCurrentProcess();
    
                ProcessModule cModule = cProcess.MainModule;
    
                var mh = Win32Api.GetModuleHandle(cModule.ModuleName);
    
                hHook = Win32Api.SetWindowsHookEx(Win32Api.WH_KEYBOARD_LL, KeyboardHookDelegate, mh, 0);
    
            }
    
            public void UnHook()
    
            {
    
                Win32Api.UnhookWindowsHookEx(hHook);
    
            }
    
            private List<Keys> preKeysList = new List<Keys>();
    
            private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)
            {
    
                if ((nCode >= 0) && (OnKeyDownEvent != null || OnKeyUpEvent != null || OnKeyPressEvent != null))
    
                {
    
                    Win32Api.KeyboardHookStruct KeyDataFromHook = (Win32Api.KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(Win32Api.KeyboardHookStruct));
    
                    Keys keyData = (Keys)KeyDataFromHook.vkCode;
    
    
                    if ((OnKeyDownEvent != null || OnKeyPressEvent != null) && (wParam == Win32Api.WM_KEYDOWN || wParam == Win32Api.WM_SYSKEYDOWN))
    
                    {
    
                        if (IsCtrlAltShiftKeys(keyData) && preKeysList.IndexOf(keyData) == -1)
    
                        {
    
                            preKeysList.Add(keyData);
    
                        }
    
                    }
    
                    if (OnKeyDownEvent != null && (wParam == Win32Api.WM_KEYDOWN || wParam == Win32Api.WM_SYSKEYDOWN))
    
                    {
    
                        KeyEventArgs e = new KeyEventArgs(GetDownKeys(keyData));
    
    
    
                        OnKeyDownEvent(this, e);
    
                    }
    
                    if (OnKeyPressEvent != null && wParam == Win32Api.WM_KEYDOWN)
    
                    {
    
                        byte[] keyState = new byte[256];
    
                        Win32Api.GetKeyboardState(keyState);
    
                        byte[] inBuffer = new byte[2];
    
                        if (Win32Api.ToAscii(KeyDataFromHook.vkCode, KeyDataFromHook.scanCode, keyState, inBuffer, KeyDataFromHook.flags) == 1)
    
                        {
    
                            KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);
    
                            OnKeyPressEvent(this, e);
    
                        }
    
                    }
    
                    if ((OnKeyDownEvent != null || OnKeyPressEvent != null) && (wParam == Win32Api.WM_KEYUP || wParam == Win32Api.WM_SYSKEYUP))
    
                    {
    
                        if (IsCtrlAltShiftKeys(keyData))
    
                        {
    
                            for (int i = preKeysList.Count - 1; i >= 0; i--)
    
                            {
    
                                if (preKeysList[i] == keyData) { preKeysList.RemoveAt(i); }
    
                            }
    
                        }
    
                    }
    
    
                    if (OnKeyUpEvent != null && (wParam == Win32Api.WM_KEYUP || wParam == Win32Api.WM_SYSKEYUP))
    
                    {
    
                        KeyEventArgs e = new KeyEventArgs(GetDownKeys(keyData));
    
                        OnKeyUpEvent(this, e);
    
                    }
    
                }
    
                return Win32Api.CallNextHookEx(hHook, nCode, wParam, lParam);
    
            }
    
            private Keys GetDownKeys(Keys key)
    
            {
    
                Keys rtnKey = Keys.None;
    
                foreach (Keys i in preKeysList)
    
                {
    
                    if (i == Keys.LControlKey || i == Keys.RControlKey) { rtnKey = rtnKey | Keys.Control; }
    
                    if (i == Keys.LMenu || i == Keys.RMenu) { rtnKey = rtnKey | Keys.Alt; }
    
                    if (i == Keys.LShiftKey || i == Keys.RShiftKey) { rtnKey = rtnKey | Keys.Shift; }
    
                }
    
                return rtnKey | key;
    
            }
    
            private Boolean IsCtrlAltShiftKeys(Keys key)
    
            {
    
                if (key == Keys.LControlKey || key == Keys.RControlKey || key == Keys.LMenu || key == Keys.RMenu || key == Keys.LShiftKey || key == Keys.RShiftKey) { return true; }
    
                return false;
    
            }
    
        }
