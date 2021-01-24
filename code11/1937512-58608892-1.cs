    class CustomForm : Form
    {
        public CustomForm()
        {
            // automatically bind a keypress event 
            this.KeyPress += new EventHandler(form_KeyPress);
        }
        private void form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close(); // Close instead of disposing
            }
        }
    }
