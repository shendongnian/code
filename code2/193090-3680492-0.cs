    void soSomething(Control ctrl)
    {
        if (ctrl is GroupBox && (ctrl.Parent is null || !(ctrl.Parent is GroupBox)))
        {
             //do something here
        }
        foreach(Control child in ctrl.Controls)
        {
            doSomething(child);
        }
    }
