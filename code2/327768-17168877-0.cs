    this.radRichTextBox1.MouseClick += radRichTextBox1_MouseClick;
    private void radRichTextBox1_MouseClick(object sender, MouseEventArgs e)
            {
                RadMessageBox.Show(e.Location.ToString());
            }
