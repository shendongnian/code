    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    
    namespace YourNameSpace
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                this.ShowInTaskbar = false;
                this.TopMost = true;
    
                #region Code for Disable ALT+TAB , WINDOWS, CTRL+ESC
                ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
                objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
                ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);
                #endregion
    
                Taskbar.Hide();
            }
    
            protected override CreateParams CreateParams
            {
                get
                {
                    var cp = base.CreateParams;
                    cp.ExStyle |= 0x80;  // Turn on WS_EX_TOOLWINDOW
                    return cp;
                }
            }
    
            #region Disable ALT+TAB , WINDOWS, CTRL+ESC
            [StructLayout(LayoutKind.Sequential)]
            private struct KBDLLHOOKSTRUCT
            {
                public Keys key;
                public int scanCode;
                public int flags;
                public int time;
                public IntPtr extra;
            }
            private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern bool UnhookWindowsHookEx(IntPtr hook);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string name);
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern short GetAsyncKeyState(Keys key);
            private IntPtr ptrHook;
            private LowLevelKeyboardProc objKeyboardProcess;
    
            private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
            {
                if (nCode >= 0)
                {
                    KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));
    
                    // Disabling Windows keys 
    
                    if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
                    }
                }
                return CallNextHookEx(ptrHook, nCode, wp, lp);
            }
    
            bool HasAltModifier(int flags)
            {
                return (flags & 0x20) == 0x20;
            }
            #endregion
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.Close();
                Taskbar.Show();
            }
        }
    
        #region TaskBar Integration to disable it.
        public class Taskbar
        {
            [DllImport("user32.dll")]
            private static extern int FindWindow(string className, string windowText);
    
            [DllImport("user32.dll")]
            private static extern int ShowWindow(int hwnd, int command);
    
            [DllImport("user32.dll")]
            public static extern int FindWindowEx(int parentHandle, int childAfter, string className, int windowTitle);
    
            [DllImport("user32.dll")]
            private static extern int GetDesktopWindow();
    
            private const int SW_HIDE = 0;
            private const int SW_SHOW = 1;
    
            protected static int Handle
            {
                get
                {
                    return FindWindow("Shell_TrayWnd", "");
                }
            }
    
            protected static int HandleOfStartButton
            {
                get
                {
                    int handleOfDesktop = GetDesktopWindow();
                    int handleOfStartButton = FindWindowEx(handleOfDesktop, 0, "button", 0);
                    return handleOfStartButton;
                }
            }
    
            private Taskbar()
            {
                // hide ctor
            }
    
            public static void Show()
            {
                ShowWindow(Handle, SW_SHOW);
                ShowWindow(HandleOfStartButton, SW_SHOW);
            }
    
            public static void Hide()
            {
                ShowWindow(Handle, SW_HIDE);
                ShowWindow(HandleOfStartButton, SW_HIDE);
            }
        }
        #endregion
    }
