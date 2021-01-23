    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace CtrLetterCopy
    {
    
        public partial class Form1 : Form
        {
            [DllImport("user32.dll")]
            private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
            [DllImport("user32.dll")]
            private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    
            const int WM_COMMAND = 0x111;
    
            enum KeyModifier
            {
                None = 0,
                Alt = 1,
                Control = 2,
                Shift = 4,
                WinKey = 8
            }
    
            public Form1()
            {
                InitializeComponent();
                this.ShowInTaskbar = false;
                int id_Ctrl = 0;     // The id of the hotkey.
                RegisterHotKey(this.Handle, id_Ctrl, (int)KeyModifier.Control, Keys.R.GetHashCode());
            }
    
            protected override void WndProc(ref Message m)
            {
                //const int WM_HOTKEY = 0x0312;
                if (m.Msg == 0x0312)
                {
                    if (m.WParam.ToInt32() == 0)
                    {
                        //do what you want here
                        SendKeyEvent();
                        
                    }
                }
                base.WndProc(ref m);
            }
    
            private void SendKeyEvent()
            {
                SendKeys.SendWait("^c");
                Thread.Sleep(500);
                string test3 = Clipboard.GetText();
                MessageBox.Show(test3);            
            } 
        }
    }
