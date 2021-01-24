        private void SetupRadioButton()
        {
            RadioButton radio1 = new RadioButton
            {
                Text = "Your Properties Here",
            };
            radio1.CheckedChanged += Radio1_CheckedChanged;
        }
        private void Radio1_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
