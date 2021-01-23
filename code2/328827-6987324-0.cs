     private void ToNextControl(bool Forward)
        {
            Control c = Parent.GetNextControl(this, Forward);         
            while (c != null && !c.TabStop) // get next control that is a tabstop
                c = Parent.GetNextControl(c, Forward);
            if (c != null)
            {
                c.Select();
                c.Focus(); // force it to focus
            }
        }
