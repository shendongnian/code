    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using System.Windows.Input;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
    
            [DllImport("user32.dll")]
            static extern int MapVirtualKey(uint uCode, uint uMapType);
    
            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();
    
            private const int WH_KEYBOARD_LL = 13;
            private const int WM_KEYDOWN = 0x0100,
                              WM_KEYUP = 0x0101,
                              S_WM_KEYDOWN = 0x0104,
                              S_WM_KEYUP = 0x0105;
    
            private static LowLevelKeyboardProc _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;
    
            private static Form1 hookForm;
    
            private static IntPtr SetHook(LowLevelKeyboardProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
                }
            }
    
            private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
    
            static bool bShortcutPressed;
    
            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (hookForm.Handle != GetForegroundWindow())
                {
                    if (nCode >= 0 && ((wParam == (IntPtr)WM_KEYDOWN) || (wParam == (IntPtr)S_WM_KEYDOWN)))
                    {
                        int vkCode = Marshal.ReadInt32(lParam);
    
                        bool bCtrl = (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl));
                        bool bAlt = (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt));
                        bool bShift = (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift));
    
                        Keys hookKey = (Keys)vkCode;
    
                        hookKey = (bCtrl) ? ((Keys.Control | hookKey)) : hookKey;
                        hookKey = (bAlt) ? ((Keys.Alt | hookKey)) : hookKey;
                        hookKey = (bShift) ? ((Keys.Shift | hookKey)) : hookKey;
    
                        Debug.Print($"hookKey {hookKey} {bCtrl} {bAlt} {bShift}");
    
                        if (!bShortcutPressed && dicTest.ContainsValue(hookKey))
                        {
                            hookForm.OnKeyDown(new System.Windows.Forms.KeyEventArgs(hookKey));
                            bShortcutPressed = true; Debug.Print($"{bShortcutPressed}");
                        }
                    }
                    
                    if (nCode >= 0 && (((wParam == (IntPtr)WM_KEYUP) || (wParam == (IntPtr)S_WM_KEYUP)))) { bShortcutPressed = false; Debug.Print($"{bShortcutPressed}"); }
                }
    
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }
    
            static Dictionary<string, Keys> dicTest = new Dictionary<string, Keys>();
    
            public void AddHotKey(Action function, Keys key, bool ctrl = false, bool shift = false, bool alt = false)
            {
                KeyDown += delegate (object sender, System.Windows.Forms.KeyEventArgs e) { if (IsHotkey(e, key, ctrl, shift, alt)) { function(); } };
            }
    
            public bool IsHotkey(System.Windows.Forms.KeyEventArgs eventData, Keys key, bool ctrl = false, bool shift = false, bool alt = false) =>
                                 eventData.KeyCode == key && eventData.Control == ctrl && eventData.Shift == shift && eventData.Alt == alt;
    
            public Form1() => InitializeComponent();
    
            private void Form1_Load(object sender, EventArgs e)
            {
                _hookID = SetHook(_proc);
    
                hookForm = this;
    
                KeyPreview = true;
    
                String[] names = Enum.GetNames(typeof(Keys));
    
                foreach (string key in names) { comboBox1.Items.Add(key); }
    
                comboBox1.SelectedItem = comboBox1.Items[0];
            }
    
            protected override void OnFormClosing(FormClosingEventArgs e) => UnhookWindowsHookEx(_hookID);
    
            private void button1_Click(object sender, EventArgs e)
            {
                Keys hookKey = (Keys)Enum.Parse(typeof(Keys), comboBox1.Text);
    
                hookKey = (checkBox1.Checked) ? ((Keys.Control | hookKey)) : hookKey;
                hookKey = (checkBox2.Checked) ? ((Keys.Alt | hookKey)) : hookKey;
                hookKey = (checkBox3.Checked) ? ((Keys.Shift | hookKey)) : hookKey;
    
                if (!dicTest.ContainsValue(hookKey))
                {
                    Debug.Print($"Going to add : {hookKey} : to our Shortcut Dictionary<>");
    
                    dicTest.Add("test", hookKey);
    
                    AddHotKey(() => { button2.PerformClick(); }, (Keys)new KeysConverter().ConvertFrom(comboBox1.Text), checkBox1.Checked, checkBox2.Checked, checkBox3.Checked);
    
                    //checkBox1.Enabled = checkBox2.Enabled = checkBox3.Enabled = comboBox1.Enabled = button1.Enabled = false;
    
                    label2.Text = "Go ahead and tryout your Shortcut now ...";
                }
                else { label2.Text = "Shortcut key is already stored in our Dictionary<> ..."; }
            }
    
            private void button2_Click(object sender, EventArgs e) { Debug.Print($"Button2 was clicked"); }
        }
    }
