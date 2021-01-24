    private void SetBackColorIncludingChildren(Control parent, Color backColor, Type controlType)
    {
        if (parent.GetType() == controlType)
        {
            parent.BackColor = backColor;
        }
        foreach(Control child in parent.Controls)
        {
            SetBackColorIncludingChildren(child, backColor, controlType);
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        ColorDialog cd = new ColorDialog();
        if (cd.ShowDialog() == DialogResult.OK)
        {
            // Pass 'this' to the method, which represents this 'Form' control
            SetBackColorIncludingChildren(this, cd.Color, typeof(Panel));
        }
    }
