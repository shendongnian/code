    foreach(Control c in group.Controls)
    {
       if(c.Name != "tbtnLock")
       {
          c.Enabled = !tbtnLock.Checked;
       }
    }
