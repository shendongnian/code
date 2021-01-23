    protected void Page_Load(object sender, EventArgs e)
    {
        ColorChange(this);
    }
    
    protected static void ColorChange(Control parent)
    {
        foreach (Control child in parent.Controls)
        {
            if (child is TextBox)
                (child as TextBox).ForeColor = Color.Red;
            
            ColorChange(child);
        }
    }
