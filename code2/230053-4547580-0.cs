    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                ComboBox combo = e.Control as ComboBox;
                if (combo != null)
                {
                    combo.SelectionChangeCommitted += new EventHandler(combo_SelectionChangeCommitted);
                }
            }
    
            void combo_SelectionChangeCommitted(object sender, EventArgs e)
            {
                DataGridViewComboBoxEditingControl combo = sender as DataGridViewComboBoxEditingControl;
                if (combo != null)
                {
                    for (int columnIndex = 0; columnIndex < dataGridView1.ColumnCount; columnIndex++)
                    {
                        if (columnIndex != combo.EditingControlDataGridView.CurrentCell.ColumnIndex)
                        {
                            dataGridView1[columnIndex, combo.EditingControlRowIndex].Value = null;
                        }
                    }
                }
            }
