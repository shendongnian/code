        public static readonly Color kFadedColor = Color.DarkGray;
        private void SetGroupBoxContentsForeColor(GroupBox aGroupbox, Color aColor)
        {
            aGroupbox.ForeColor = aColor;
            foreach (Control lControl in aGroupbox.Controls)
            {
                lControl.ForeColor = aColor;
            }
        }
        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Again, if you need to expand the ComboBox entries,
            // this will need additional logic
            if (cb1.SelectedIndex == 0)
            {
                SetGroupBoxContentsForeColor(gb1, mPrevioslySavedColorToRestore);
                SetGroupBoxContentsForeColor(gb2, kFadedColor);
            }
            else
            {
                SetGroupBoxContentsForeColor(gb2, mPrevioslySavedColorToRestore);
                SetGroupBoxContentsForeColor(gb1, kFadedColor);
            }
        }
