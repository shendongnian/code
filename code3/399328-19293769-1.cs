    object clickBox = null;
     private void checkBox_Click(object sender, EventArgs e)
        {
            clickBox = sender;
            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    if (c != clickBox)
                    {
                        ((CheckBox)c).Checked = false;
                    }
                }
            }
