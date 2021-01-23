    foreach (Control c in Controls)
    {
        TextBox tb = c as TextBox;
        if (tb != null)
        {
            tb.BackColor = System.Drawing.Color.Red; 
        }
    }
