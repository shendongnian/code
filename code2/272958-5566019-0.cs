    class MyDiallerDialog : Form
    {
        public String DialledNumber
        {
            get { return this.txtNumber.Text; } // Or however the form stores its number...
        }
    }
    class MyMainForm : Form
    {
        void btnCall_Click(object sender, EventArgs e)
        {
            using (var dialog = new MyDiallerDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    String number = dialog.DialledNumber;
                    // do something interesting with the number...
                }
            }
        }
    }
