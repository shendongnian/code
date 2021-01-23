    private void grvList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                 if (grvList.Columns[grvList.CurrentCell.ColumnIndex].Name.Equals("routing_ID"))
                    {
                        ComboBox cmbprocess = e.Control as ComboBox;
                        cmbprocess.SelectedIndexChanged += new EventHandler(grvcmbProcess_SelectedIndexChanged);
                    }
            }
    
    
     private void grvcmbProcess_SelectedIndexChanged(object sender, EventArgs e)
            {
                ComboBox cmbprocess = (ComboBox)sender;
                if (cmbprocess.SelectedValue != null)
                {
                   /// Your Code goes here
                }
    
            }
