    public Control FindControlRecursive(Control control, string id) {
        Control x = control.FindControl(id);
        foreach (Control c in control.Controls) {
            if (x != null) {
                break;                
            }
            x = c.FindControlRecursive(id);           
        }
        return x; 
    }
