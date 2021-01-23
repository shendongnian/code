    public IMeditor(IMui IMui, IMuser U, string User)
        {
            InitializeComponent();
            this.IMui = IMui;
            imu = U;
            if (imu.UID == 0)
            {
                Add.Text = "Add";
                imu.name = user;
            }
            else
                Add.Text = "Update";
            AuthChat.Checked = imu.AuthChat == 1;
            AuthTac1.Checked = imu.AuthTac1 == 1;
            AuthTac2.Checked = imu.AuthTac2 == 1;
            AuthTac3.Checked = imu.AuthTac3 == 1;
            AuthTac4.Checked = imu.AuthTac4 == 1;
            AuthTac5.Checked = imu.AuthTac5 == 1;
            AuthTac6.Checked = imu.AuthTac6 == 1;
            AuthTac7.Checked = imu.AuthTac7 == 1;
            AuthTac8.Checked = imu.AuthTac8 == 1;
            AuthTac9.Checked = imu.AuthTac9 == 1;
            AuthTac10.Checked = imu.AuthTac10 == 1;
    
            switch (imu.Transport.ToLower()) {
                case "aim":   Transport.SelectedIndex = 0; break;
                case "gtalk": Transport.SelectedIndex = 1; break;
                case "msn":   Transport.SelectedIndex = 2; break;
                case "yahoo": Transport.SelectedIndex = 3; break;
            }
    
             AuthChat.CheckedChanged += new EventHandler(CheckChangedHandler);
             AuthChat1.CheckedChanged += new EventHandler(CheckChangedHandler);
    
        }
    
     void CheckChangedHandler(Object obj, EventArgs args)
            {
                if (obj == AuthChat)
                {
                    MessageBox.Show("Checked changed for AuthChat");
                }
                else if (obj == AuthChat1)
                {
                    MessageBox.Show("Checked changed for AuthChat1");
                }
            }
