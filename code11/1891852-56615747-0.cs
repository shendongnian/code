    private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
    {
        var window = AutomationElement.FromHandle((IntPtr)comboBox1.SelectedValue);
        if (window != null) {
            GetCommElement(window, ControlType.Edit);
        }
    }
    private void GetCommElement(AutomationElement parent, ControlType controlType)
    {
        element = parent.FindFirst(TreeScope.Subtree, 
            new PropertyCondition(AutomationElement.ControlTypeProperty, controlType));
    }
