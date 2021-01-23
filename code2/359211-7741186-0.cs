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
        typeof(Form).InvokeMember(string.Format("{0}s", ((Control)sender).Name), BindingFlags.InvokeMethod | BindingFlags.NonPublic, null, null, new object[] { Clipboard.GetText() });
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        SetTextBoxClickHandler(this.Controls);
    }
