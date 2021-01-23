            private MainMenu mainMenu1;
            private MenuItem mnuBack;
            myMessageWindow messageWindow;
            public HButtons()
            {
                InitializeComponent();
                this.messageWindow = new myMessageWindow(this); 
                RegisterHKeys.RegisterRecordKey(this.messageWindow.Hwnd);
            }
            protected override void Dispose(bool disposing)
            {
                RegisterHKeys.UnRegisterRecordKey();
                base.Dispose(disposing);
            }
            public void ButtonPressed(int button)
            {
                switch (button)
                {
                    case (int)KeysHardware.VK_APP1:
                        MessageBox.Show("VK_APP1 pressed!");
                        break;
                    case (int)KeysHardware.GreenPhoneButton:
                        MessageBox.Show("GreenPhoneButton pressed!");
                        break;
                    case (int)KeysHardware.RedPhoneButton:
                        MessageBox.Show("RedPhoneButton pressed!");
                        break;
                    case (int)KeysHardware.VK_TSOFT1:
                        MessageBox.Show("VK_TSOFT1 pressed!");
                        break;
                }
            }
            private void InitializeComponent()
            {
                this.mainMenu1 = new System.Windows.Forms.MainMenu();
                this.mnuBack = new System.Windows.Forms.MenuItem();
                this.SuspendLayout();
                // 
                // mainMenu1
                // 
                this.mainMenu1.MenuItems.Add(this.mnuBack);
                // 
                // mnuBack
                // 
                this.mnuBack.Text = "Back";
                this.mnuBack.Click += new System.EventHandler(this.mnuBack_Click);
                // 
                // HButtons
                // 
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
                this.ClientSize = new System.Drawing.Size(240, 268);
                this.Menu = this.mainMenu1;
                this.MinimizeBox = false;
                this.Name = "HButtons";
                this.Text = "HW buttons";
                this.ResumeLayout(false);
            }
            private void mnuBack_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
        public class myMessageWindow : MessageWindow
        {
            public const int WM_HOTKEY = 0x0312;
            HButtons example;
            public myMessageWindow(HButtons anExample)
            {
                this.example = anExample;
            }
            protected override void WndProc(ref Message msg)
            {
                switch (msg.Msg)
                {
                    case WM_HOTKEY:
                        example.ButtonPressed(msg.WParam.ToInt32());
                        return;
                }
                base.WndProc(ref msg);
            }
        }
        public class RegisterHKeys
        {
            [DllImport("coredll.dll", SetLastError = true)]
            public static extern bool RegisterHotKey(
                IntPtr hWnd, // handle to window
                int id, // hot key identifier
                KeyModifiers Modifiers, // key-modifier options
                int key //virtual-key code
            );
            [DllImport("coredll.dll")]
            private static extern bool UnregisterFunc1(
                KeyModifiers modifiers, 
                int keyID);
            public static void RegisterRecordKey(IntPtr hWnd)
            {
                UnregisterFunc1(KeyModifiers.Windows, (int)KeysHardware.VK_APP1);
                RegisterHotKey(hWnd, (int)KeysHardware.VK_APP1, KeyModifiers.Windows, (int)KeysHardware.VK_APP1);
                UnregisterFunc1(KeyModifiers.None, (int)KeysHardware.GreenPhoneButton);
                RegisterHotKey(hWnd, (int)KeysHardware.GreenPhoneButton, KeyModifiers.None, (int)KeysHardware.GreenPhoneButton);
                UnregisterFunc1(KeyModifiers.None, (int)KeysHardware.RedPhoneButton);
                RegisterHotKey(hWnd, (int)KeysHardware.RedPhoneButton, KeyModifiers.None, (int)KeysHardware.RedPhoneButton);
                UnregisterFunc1(KeyModifiers.None, (int)KeysHardware.VK_TSOFT1);
                RegisterHotKey(hWnd, (int)KeysHardware.VK_TSOFT1, KeyModifiers.None, (int)KeysHardware.VK_TSOFT1);
            }
            public static void UnRegisterRecordKey()
            {
                UnregisterFunc1(KeyModifiers.Windows, (int)KeysHardware.VK_APP1);
                UnregisterFunc1(KeyModifiers.None, (int)KeysHardware.GreenPhoneButton);
                UnregisterFunc1(KeyModifiers.None, (int)KeysHardware.RedPhoneButton);
                UnregisterFunc1(KeyModifiers.None, (int)KeysHardware.VK_TSOFT1);
            }
        }
        ///// <summary>
        ///// Summary description for hwButtons.
        ///// </summary>
        //public class hwButtons
        //{
        //    public hwButtons()
        //    {
        //        HButtons theBtns = new HButtons();
        //    }
        //}
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8,
            Modkeyup = 0x1000,
        }
        //public enum KeysHardware : int
        //{
        //    Hardware1 = 193, //0xC1
        //    Hardware2 = 194,
        //    Hardware3 = 195,
        //    Hardware4 = 196,
        //    Hardware5 = 197
        //}
        public enum KeysHardware : int
        {
            VK_F1 = 0x70,
            VK_F2 = 0x71,
            VK_F3 = 0x72,
            VK_F4 = 0x73,
            VK_F5 = 0x74,
            VK_F6 = 0x75,
            VK_F7 = 0x76,
            VK_F8 = 0x77,
            VK_F9 = 0x78,
            VK_F10 = 0x79,
            VK_F11 = 0x7A,
            VK_F12 = 0x7B,
            VK_TSOFT1 = VK_F1, // Softkey 1
            VK_TSOFT2 = VK_F2, // Softkey 2
            VK_TTALK = VK_F3, // Talk = Green Phone Button
            VK_TEND = VK_F4, // End = Red Phone Button
            VK_APP1 = 0xC1, // up to 6 other hardware buttons
            VK_APP2 = 0xC2,
            VK_APP3 = 0xC3,
            VK_APP4 = 0xC4,
            VK_APP5 = 0xC5,
            VK_APP6 = 0xC6,
            RedPhoneButton = VK_TEND,
            GreenPhoneButton = VK_TTALK
        }
