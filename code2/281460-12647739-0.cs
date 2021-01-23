    public void button1_Click(Office.IRibbonControl control)
    {
        if (control.Id == "button1")
        {
            // your code
            clicked = true; // a boolean variable
        }
    }
    public bool button1_EnabledChanged(Office.IRibbonControl control)
    {
        if (control.Id == "button1")
            return !clicked;
    }
