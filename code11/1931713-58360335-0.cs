        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.AutoPopDelay = 5000;
            tip.InitialDelay = 1000;
            tip.ReshowDelay = 500;
            tip.SetToolTip(radioButton1, "Choose to Add Onions");
            tip.SetToolTip(radioButton2, "Choose to Add Pickles");
        }
