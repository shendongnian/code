    private void function enablecontrols(ControlCollection Controls)
    {
       foreach(Control c in Controls)
       {
         c.Enabled = true;
         if (c.ControlCollection.Count > 0) enablecontrols(c.Controls);
       }
    }
