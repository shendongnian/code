    private void FindSelecedControl(Control control) 
    {
        if (control is TextBox)
        {
            TextBox txt = (TextBox)control;
            txt.Enabled = false;
        }
        else
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                FindSelecedControl(control.Controls[i]);
            }
        } 
    }
    
    foreach (Control control1 in this.Form.Controls) 
    {
         FindSelecedControl(control1); 
    }
