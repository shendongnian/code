    private void myDummyUserControl_Load(object sender, EventArgs e)
    {
        var uc = (DummyUserControl)sender;
        uc.Parent.ControlAdded += new ControlEventHandler(Parent_ControlAdded);
        foreach (Control c in uc.Parent.Controls)
        {
            if (uc == c)
                continue;
            c.Paint += new PaintEventHandler(c_Paint);
        }
    }
    
    void c_Paint(object sender, PaintEventArgs e)
    {
        //checks & paint stuff here
    }
    
    void Parent_ControlAdded(object sender, ControlEventArgs e)
    {
        e.Control.Paint += new PaintEventHandler(c_Paint);
    }
