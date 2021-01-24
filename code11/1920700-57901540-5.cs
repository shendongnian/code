    public bool Check_Inputs_Empty_Exception(List<Control> Exception_Control_List, TableLayoutPanel TableLayoutPanel)
    {
        bool result = false;
        var emptyTextboxes = TableLayoutPanel.Controls
           .OfType<TextBox>()
           .Where( c => string.IsNullOrEmpty(c.Text) )
           .ToList();
        foreach (var control in emptyTextboxes)
        {
            if (!Exception_Control_List.Any( c => c == control )) 
            {
                MessageBox.Show(control.Name + "  is empty");
                result = true;
            }
        }
        return result;
    }
