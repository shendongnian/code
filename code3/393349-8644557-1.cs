    private void Form1_Load(object sender, EventArgs e)
    {
        DescTextBox.Visible = false;
        DisplayTextBox = new RichTextBox();
        DisplayTextBox.Location = new Point(15, 31);
        DisplayTextBox.Height = 258;
        DisplayTextBox.Width = 303;
        panel1.Controls.Add(DisplayTextBox);
    } 
