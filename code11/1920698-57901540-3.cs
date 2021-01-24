    public bool Check_Inputs_Empty_Exception(List<Control> Exception_Control_List, TableLayoutPanel TableLayoutPanel)
    {
        bool result = false;
        var emptyControls = TableLayoutPanel.Controls
           .Cast<Control>()
           .Where( c => string.IsNullOrEmpty(c.Text) )
           .ToList();
        foreach (var control in emptyControls)
        {
            if (!Exception_Control_List.Any( c => c == control )) 
            {
                MessageBox.Show(Control.Name + "  is empty");
                result = true;
            }
        }
        return result;
    }
