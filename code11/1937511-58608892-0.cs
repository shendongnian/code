    class CustomForm : Form
    {
        private void form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
