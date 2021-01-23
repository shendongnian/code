    ChangeColor_Click
    {
       ChangeAllBG(this);
    }
    
    void ChangeAllBG(Control c)
    {
        c.BackColor=Color.Teal;
        foreach (Control ctl in c.Controls)
            ChangeAllBG(ctl);
    }
