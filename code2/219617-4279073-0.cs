    public void ChangeControlsColours(Controls in_c)
    {
        foreach (Control c in in_c)
        {
            c.BackColor = Colors.Black;
            c.ForeColor = Colors.White;
            if (c.Controls.length >0 ) //I'm not 100% this line is correct, but I think you get the idea, yes?
                ChangeControlsColours(c.Controls)
        }
    
    }
