    public bool Check_Inputs_Empty_Exception(List<Control> Exception_Control_List, TableLayoutPanel TableLayoutPanel)
    {
        bool is_empy = false;
        foreach (Control control in TableLayoutPanel.Controls)
        {
            if (Exception_Control_List.Any( c => c == control )) continue;
            if (String.IsNullOrWhiteSpace(control.Text))
            {
                MessageBox.Show(Control.Name + "  is empty");
                is_empy = true;
            }
        }
        return is_empy;
    }
