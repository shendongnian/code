    private void btGetValue_Click(object sender, EventArgs e)
    {
        foreach (TabPage page in tabControl1.TabPages)
        {
            foreach (Control control in page.Controls)
            {
                // get the first textbox's value
                if (control is TextBox && control.Name == "TextBox1")
                {
                    Console.WriteLine(((TextBox)control).Text);
                }
            }
        }
    }
