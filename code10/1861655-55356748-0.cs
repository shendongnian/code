        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.ColumnIndex == 0)
                    dataGridView1.ShowCellToolTips = false;
                else
                    dataGridView1.ShowCellToolTips = true;
            }
        }
