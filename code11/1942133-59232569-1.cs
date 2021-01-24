    using DesktopWPFAppLowLevelKeyboardHook;
    using System;
    using System.Windows.Forms;
    
    namespace AppLowLevelKeyboardHook
    {
        public partial class Form1 : Form
        {
            private LowLevelKeyboardListener _listener;
            public int ctrlStatus;
            public int cStatus;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, EventArgs e)
            {
                _listener = new LowLevelKeyboardListener();
                _listener.OnKeyPressed += _listener_OnKeyPressed;
    
                _listener.HookKeyboard();
            }
    
            private void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
            {
                this.textBox_DisplayKeyboardInput.Text += e.KeyPressed.ToString() + e.KeyStatus.ToString();
    
                if (e.KeyStatus == 1 && (e.KeyPressed.ToString() == "LeftCtrl" | e.KeyStatus.ToString() == "RightCtrl"))
                {
                    if (ctrlStatus == 0)
                    {
                        ctrlStatus = ctrlStatus + 1;
                    }
                }
                else if (e.KeyStatus == 1 && e.KeyPressed.ToString() == "C")
                {
                    if (ctrlStatus == 1 && (cStatus == 0 || cStatus == 2))
                    {
                        cStatus = cStatus + 1;
                        if (cStatus == 1)
                        {
                            timer1.Start();
                        }
                    }
                }
                else if (e.KeyStatus == 0 && (e.KeyPressed.ToString() == "LeftCtrl" | e.KeyStatus.ToString() == "RightCtrl"))
                {
                    if (ctrlStatus == 1)
                    {                    
                        ctrlStatus = ctrlStatus + 1;
                    }
    
                }
                else if (e.KeyStatus == 0 && e.KeyPressed.ToString() == "C")
                {
                    if (ctrlStatus == 1)
                    {
                        if (cStatus == 1)
                        {
                            cStatus = cStatus + 1;
                        }
                        else if (cStatus == 3)
                        {
                            cStatus = cStatus + 1;
                            
                        }
                    }
                }
                    
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                if (ctrlStatus == 2 && cStatus == 4)
                {
                    //do something
                    label1.Text = "";
                    label1.Refresh();
                    label1.Text = Clipboard.GetText(TextDataFormat.Text);
                    //\do something
                }
                ctrlStatus = 0;
                cStatus = 0;
                timer1.Stop();
            }
    
            private void Window_Closing(object sender, FormClosingEventArgs e)
            {
                _listener.UnHookKeyboard();
            }
    
        }
    }
