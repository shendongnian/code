    public Control FindControlRecursive(Control control, string id) {
        Control x = control.FindControl(id);
        foreach (Control c in control.Controls) {
            if (x == null) {
                x = c.FindControlRecursive(id);
            }
            else {
                break;                
            }                 
        }
        return x; 
    }
