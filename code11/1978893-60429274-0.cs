    Foreach(TextBox txt in this.Controls.OfType<TextBox>())
    {
     if (string.IsNullOrWhitespace(txt.Text))
    {
     errorprovider1.SetError(txt, "Empty Field");
    }
    }
