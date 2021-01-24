    private void selectedCellsButton_Click(object sender, System.EventArgs e)
    {
        Int32 selectedCellCount =
            dataGridView1.GetCellCount(DataGridViewElementStates.Selected);
        if (selectedCellCount > 0)
        {
                for (int i = 0; i < selectedCellCount; i++)
                {
                    (dataGridView1.SelectedCells[i].RowIndex.ToString());
                    (dataGridView1.SelectedCells[i].ColumnIndex.ToString());
                }
              
            }
        }
    }
