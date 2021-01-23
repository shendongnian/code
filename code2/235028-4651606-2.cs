        public Font SelectedFont { get; set; }
        public FontDialog()
        {
           //set your defaults here
        }
        public FontDialog (Font font)
        {
           SelectedFont = font;
           //dont forget to set the passed in font to your ui values here
        }
        private void acceptButton_Click(object sender, EventArgs e)
        {
            SelectedFont = //How ever you create your font object;
        }
