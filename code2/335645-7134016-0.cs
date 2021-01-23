      private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
            {
                int i = e.RowIndex;
                int j = e.ColumnIndex;
                if (i == -1 && j == -1)
                {
                   // here you need to paint the cell 
                }
           }
