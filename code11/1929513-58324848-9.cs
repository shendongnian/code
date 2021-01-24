        public static readonly Color kHighlightedColor = Color.Orange;
        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Again, if you need to expand the ComboBox entries,
            // this will need additional logic
            if (cb1.SelectedIndex == 0)
            {
                gb1.ForeColor = kHighlightedColor;
                gb2.ForeColor = mPrevioslySavedColorToRestore;
            }
            else
            {
                gb2.ForeColor = kHighlightedColor;
                gb1.ForeColor = mPrevioslySavedColorToRestore;
            }
        }
