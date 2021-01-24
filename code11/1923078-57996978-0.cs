    public bool textSchreiben(string textStr, int x, int y)
    {
        try
        {
         Label textControl = new Label();
         textControl.Text = textStr;
         textControl.Location = new Point(x, y);
         textControl.ForeColor = Color.White;
         panel1.Controls.Add(textControl);
        return true;
        }
        catch { return false; }
    }
