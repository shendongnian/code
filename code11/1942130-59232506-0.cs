    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using System.Text;
    
    namespace GlobalHotkeyExampleForm
    {
        public partial class Form1 : Form
        {
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            public int shortkey = 0;
    
            [DllImport("user32.dll")]
            private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
            [DllImport("user32.dll")]
            private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    
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
    
                int id = 0;     // The id of the hotkey. 
                RegisterHotKey(this.Handle, id, (int)KeyModifier.Control, Keys.C.GetHashCode());       // Register CTRL + C as global hotkey. 
            }
    
            protected override void WndProc(ref Message m)
            {
                base.WndProc(ref m);
    
                if (m.Msg == 0x0312)
                {
                    /* Note that the three lines below are not needed if you only want to register one hotkey.
                     * The below lines are useful in case you want to register multiple keys, which you can use a switch with the id as argument, or if you want to know which key/modifier was pressed for some particular reason. */
    
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);                  // The key of the hotkey that was pressed.
                    KeyModifier modifier = (KeyModifier)((int)m.LParam & 0xFFFF);       // The modifier of the hotkey that was pressed.
                    int id = m.WParam.ToInt32();                                        // The id of the hotkey that was pressed.
    
                    if (modifier == KeyModifier.Control && key == Keys.C)
                    {
                        shortkey = shortkey + 1;
    
                        label1.Text = (shortkey.ToString());
    
                        //if I enebale this code it works partially. The UnregisterHotKey and RegisterHotKey works perfectly and alone also SendKeys works prefectly, but together it doesn't:
                        //it doesn't recognize that CTRL is still pressed and I don't want to do CTRL C + CTRL C and I don't like "to stole" the shortkey from other apps!;
                        //I tried to use SendKeys to resend CTRL C or onlt CTRL but it doens't work and it creates only Register problems 
                        //UnregisterHotKey(this.Handle, 0); //unregister the hotkey catching
                        //SendKeys.Send("^c"); //send key to active application (it doesn't matter if this is the application)               
                        ////register the hotkey catching as C only
                        //RegisterHotKey(this.Handle, id, (int)KeyModifier.Control, Keys.C.GetHashCode());
                        //SendKeys.Send("^c");
                        //SendKeys.Send("^");
                        timer1.Start();
                    }
    
                    //MessageBox.Show("Hotkey has been pressed!");
                    // do something
                }
            }
    
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                UnregisterHotKey(this.Handle, 0);       // Unregister hotkey with id 0 before closing the form. You might want to call this more than once with different id values if you are planning to register more than one hotkey.
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.Close();
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
    
                if (shortkey == 2)
                {
                    string returnMyText = Clipboard.GetText(TextDataFormat.Text);
                }
                shortkey = 0;
                timer1.Stop();
            }
        }
    }
