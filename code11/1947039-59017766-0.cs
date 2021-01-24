    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Diagnostics;
    namespace WindowsFormsApp1
    {
        public partial class UserControl1 : UserControl
        {
            const int WH_GETMESSAGE = 0x03;
            const int WM_MOUSEHOVER = 0x02A1;
            const int WM_MOUSELEAVE = 0x02A3;
            const int WM_MOUSEMOVE = 0x0200;
            private delegate int HookProc(int code, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll", EntryPoint = "SetWindowsHookEx", SetLastError = true)]
            static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hMod, uint dwThreadId);
            [DllImport("user32.dll")]
            static extern bool UnhookWindowsHookEx(IntPtr hHook);
            [DllImport("user32.dll")]
            static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public static extern IntPtr GetModuleHandle(string lpModuleName);
            [DllImport("user32.dll")]
            static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr lpdwProcessId);
            IntPtr _hook;
            HookProc _hookProc;
            public UserControl1()
            {
                InitializeComponent();
                this.HandleCreated += (sender, e) =>
                {
                    _hookProc = new HookProc(GetMsgHookProc);
                    _hook = SetWindowsHookEx(
                        WH_GETMESSAGE,
                        _hookProc,
                        GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName),
                        GetWindowThreadProcessId(this.Handle, IntPtr.Zero));
                };
                this.Disposed += (sender, e) => 
                {
                    UnhookWindowsHookEx(_hook);
                };
            }
            private bool IsOurChild(Control ctl)
            {
                if (ctl == null)
                    return false;
                if (ctl.Parent?.Handle == ctl.FindForm()?.Handle)
                    return ctl.Handle == this.Handle;
                return IsOurChild(ctl.Parent);
            }
            private int GetMsgHookProc(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode < 0)
                    return CallNextHookEx(_hook, nCode, wParam, lParam);
                Message m = Marshal.PtrToStructure<Message>(lParam);
                Control ctl = Control.FromHandle(m.HWnd);
                if (IsOurChild(ctl))
                {
                    if (m.Msg == WM_MOUSEHOVER || m.Msg == WM_MOUSEMOVE)
                        this.BackColor = Color.Red;
                    if (m.Msg == WM_MOUSELEAVE)
                        this.BackColor = Color.Blue;
                }
                return CallNextHookEx(_hook, nCode, wParam, lParam);
            }
        }
    }
 
