    private void DGV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
      if (DGV.CurrentCell.ColumnIndex == comboColumnIndex && e.Control is ComboBox)
      {
        ComboBox comboBox = e.Control as ComboBox;
        comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
      }
    }
