    private void ultraGrid1_BeforeRowDeactivate(object sender, CancelEventArgs e)
    {
        if (!first) //Ignore this step if application has just started
        {
           UltraGrid g = (UltraGrid)(sender);
           r = g.ActiveRow;
           ultraGrid1.Rows[g.ActiveRow.Index].Cells["Is Closed"].Value = false; 
        }
    }
