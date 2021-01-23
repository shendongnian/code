    using System;
    using System.Windows.Forms;
    namespace WindowsApplication1 {
        public partial class Form1 : Form, IMessageFilter {
            private Timer mTimer;
            private int mDialogCount;
            public Form1() {
                InitializeComponent();
                mTimer = new Timer();
                mTimer.Interval = 2000;
                mTimer.Tick += LogoutUser;
                mTimer.Enabled = true;
                Application.AddMessageFilter(this);
            }
            public bool PreFilterMessage(ref Message m) {
                // Monitor message for keyboard and mouse messages
                bool active = m.Msg == 0x100 || m.Msg == 0x101;  // WM_KEYDOWN/UP
                active = active || m.Msg == 0xA0 || m.Msg == 0x200;  // WM_(NC)MOUSEMOVE
                active = active || m.Msg == 0x10;  // WM_CLOSE, in case dialog closes
                if (active) {
                    if (!mTimer.Enabled) label1.Text = "Wakeup";
                    mTimer.Enabled = false;
                    mTimer.Start();
                }
                return false;
            }
            private void LogoutUser(object sender, EventArgs e) {
                // No activity, logout user
                if (mDialogCount > 0) return;
                mTimer.Enabled = false;
                label1.Text = "Time'z up";
            }
            private void button1_Click(object sender, EventArgs e) {
                mDialogCount += 1;
                Form frm = new Form2();
                frm.ShowDialog();
                mDialogCount -= 1;
                mTimer.Start();
            }
        }
    }
