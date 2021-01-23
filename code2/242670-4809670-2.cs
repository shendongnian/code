    foreach (Control ctrl in this.Controls)
    {
        TextBox tb = ctrl as TextBox;
        if (tb != null)
        {
            int max = tb.MaxLength;
            // ...
        }
    }
