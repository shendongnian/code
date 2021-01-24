    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    using Keys = System.Windows.Forms.Keys;
    namespace BarcodeScanner
    {
    public class CouldntHookException : Exception
    {
        public override string Message
        {
            get
            {
                return "barcode_input_handler couldnt add itself to the hook chain.";
            }
        }
        public override string ToString()
        {
            return Message;
        }
    }
    public class BarcodeHandler : IDisposable
    {
        private delegate long delLowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void delInput(string scanCode);
        public event delInput InputEvent;
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern long SetWindowsHookEx(int idHook,
            delLowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(long hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern long CallNextHookEx(long hhk, int nCode,
            IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const Keys HK_PRE = Keys.F5;  //0x0007;
        private const Keys HK_PRE_VALID = Keys.OemOpenBrackets;
        private const Keys HK_SUFF = Keys.Oemtilde; //0x000A;
        private long _hHook = 0;
        private StringBuilder _buffer;
        private bool _hookFlag;
        private bool _hookValid;
        delLowLevelKeyboardProc _procHook;
        taglParam _lastKey;
        struct taglParam
        {
            public int _vkCode, _scanCode, _flags, _time;
            public taglParam(int vkCode, int scanCode, int flags, int time)
            { _vkCode = vkCode; _scanCode = scanCode; _flags = flags; _time = time; }
        };
        public BarcodeHandler()
        {
            _buffer = new StringBuilder(128);
            _hookFlag = false;
            _hookValid = false;
            _procHook = new delLowLevelKeyboardProc(HookHandleProc);
            _hHook = SetHook();
            if (_hHook == 0)
                throw new CouldntHookException();
        }
        ~BarcodeHandler()
        {
            Dispose();
        }
        private long SetHook()
        {
            using (Process cp = Process.GetCurrentProcess())
            using (ProcessModule cm = cp.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, _procHook,
                    GetModuleHandle(cm.ModuleName), 0);
            }
        }
        private long HookHandleProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0 || wParam != (IntPtr)WM_KEYDOWN)
                return CallNextHookEx(_hHook, nCode, wParam, lParam);
            taglParam lp = (taglParam)Marshal.PtrToStructure(lParam, typeof(taglParam));
            if (_hookFlag)
            {
                if ((Keys)lp._vkCode == HK_SUFF)
                {
                    _hookFlag = false;
                    _hookValid = false;
                    //trigger event here
                    //use begininvoke instead of invoke  ;)
                    InputEvent.Invoke(_buffer.ToString());
                    return -1;
                }
                _buffer.Append((char)lp._vkCode);
                return -1;
            }
            else if ((Keys)lp._vkCode == HK_PRE)
            {
                _hookValid = true;
                _lastKey = lp;
            }
            else if (_hookValid && (Keys)lp._vkCode == HK_PRE_VALID)
            {
                if (lp._time - _lastKey._time < 50)
                {
                    _buffer.Clear();
                    _hookFlag = true;
                    return -1;
                }
                else
                    _hookValid = false;
            }
            return CallNextHookEx(_hHook, nCode, wParam, lParam);
        }
        private bool DeleteHook()
        {
            return UnhookWindowsHookEx(_hHook);
        }
        public void Dispose()
        {
            DeleteHook();
            GC.SuppressFinalize(this);
        }
    }
    }
