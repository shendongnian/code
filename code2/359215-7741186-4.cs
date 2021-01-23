    public void SetTextBoxClickHandler(Control control)
    {
        foreach (Control childControl in control.Controls)
        {
            if (childControl is TextBox)
            {
                childControl.Click += this.MyClickHandler;
                continue;
            }
            if (item.Controls == null)
                continue;
            SetTextBoxClickHandler(childControl);
        }
    }
    
    private void MyClickHandler(object sender, MouseEventArgs e)
    {
        TextBox textBox = sender as Textbox;
        if (textBox == null)
            return;
        textBox.ForeColor = Color.Black;
        textBox.Text = Clipboard.GetText();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        SetTextBoxClickHandler(this.Controls);
    }
