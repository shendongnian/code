    private void function enablecontrols(ControlCollection Controls)
    {
       foreach(Control c in Controls)
       {
         c.Enabled = true;
         if (c.HasControls) enablecontrols(c.Controls);
       }
    }
