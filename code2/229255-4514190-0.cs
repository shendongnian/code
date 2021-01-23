    private void Form1_Shown(object sender, EventArgs e)
    {
        Control control = FindFocusedControl(this);
        MessageBox.Show("The focused control " + control.Name + " is of type " + control.GetType());
    }
    public static Control FindFocusedControl(Control control)
    {
        var container = control as ContainerControl;
        while (container != null)
        {
            control = container.ActiveControl;
            container = control as ContainerControl;
        }
        return control;
    }
