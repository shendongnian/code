    void ProcessControls(Control control)
    {
        if(control is IMyInterface) //whatever your interface name is
        {
            (control as IMyInterface).MethodName();
        }
        
        foreach(Control child in control.Controls)
        {
            ProcessControls(child);
        }
    }
