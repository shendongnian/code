    private void InitEvents()
    {
        dgv4.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler( dgv4EditingControlShowing );
    }
    private void dgv4EditingControlShowing( object sender, DataGridViewEditingControlShowingEventArgs e )
    {
       ComboBox ocmb = e.Control as ComboBox;
       if ( ocmb != null )
       {
          ocmb.SelectedIndex = 0;
       }
    }
