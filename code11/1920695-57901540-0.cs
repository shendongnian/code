    public bool Check_Inputs_Empty_Exception(List<Control> Exception_Control_List, TableLayoutPanel TableLayoutPanel)
    {
        bool is_empy = false;
        foreach (Control Control in TableLayoutPanel.Controls)
        {
            bool found = false;
            for (int i = 0; i < Exception_Control_List.Count; i++)
            {
                if (Control == Exception_Control_List[i]) 
                {
                    found = true;
                    break;
                }
            }
            if (found) continue;
            if (String.IsNullOrWhiteSpace(Control.Text))
            {
                MessageBox.Show(Control.Name + "  is empty");
                is_empy = true;
            }
        }
        return is_empy;
    }
