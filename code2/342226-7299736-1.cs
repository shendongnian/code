    private void ResizeControl (Control control, Control parent) {
        control.Location = new Point (parent.ClientRectangle.Left, parent.ClientRectangle.Top);
        control.Size = new Size (parent.ClientRectangle.Width, parent.ClientRectangle.Height);
    
        if(!(control is PropertyGrid)) {
           foreach (Control child in control.Controls) {
               ResizeControl (child, control);
           }
        }
    }
