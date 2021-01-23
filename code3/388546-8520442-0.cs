    public void Selectpropertygrid()
    {            
        foreach (Control c in dock_Control1.Controls)
        {
            c.MouseClick -= c_MouseClick;
            c.MouseClick += c_MouseClick;
        }
        foreach (Control ctr in this.Controls)
        {
            ctr.MouseClick -= c_MouseClick;
            ctr.MouseClick += c_MouseClick;
        }
     }
