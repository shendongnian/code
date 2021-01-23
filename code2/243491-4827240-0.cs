    private void dg_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      if (dg.CurrentCell.ColumnIndex == [yourcolumnindex])
      {
        ComboBox cmbox = e.Control as ComboBox;
        cmbox.SelectedValueChanged += new EventHandler(cmbox_SelectedValueChanged);
      }
    }
