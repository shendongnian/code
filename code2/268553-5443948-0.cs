        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            num1.ValueChanged += new EventHandler(numericUpDown1_ValueChanged);
        }
        void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("New value : " +num1.Value);
        }
