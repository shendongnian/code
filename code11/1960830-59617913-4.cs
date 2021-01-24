    private void Form1_Load(object sender, EventArgs e)
    {
        // Make the RichTextBox look and behave like a Label control
        richTextBox1.BorderStyle = BorderStyle.None;
        richTextBox1.BackColor = System.Drawing.SystemColors.Control;
        richTextBox1.ReadOnly = true;
        richTextBox1.Text = "Hipopotamus";
        // I added a small, blank Label control to the form which I use to capture the Focus
        // from this control, so the user can't see the caret or select/highlight/edit text
        richTextBox1.GotFocus += (s, ea) => { lblHidden.Focus(); };
    }
