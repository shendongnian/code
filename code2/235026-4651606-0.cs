        public Font SelectedFont { get; set; }
        public FontDialog()
        {
           //set your defaults here
        }
        public FontDialog (Font font)
        {
           Font = font;
           //dont forget to set the passed in font to your ui values here
        }
        private void acceptButton_Click(object sender, EventArgs e)
        {
            selectFont = //How ever you create your font object;
        }
