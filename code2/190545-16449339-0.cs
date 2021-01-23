        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BoardStatusView bs = dataGridView1.Rows[e.RowIndex].DataBoundItem as BoardStatusView;
                bool disabled = !bs.Upgradeable();
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = disabled;
                if (disabled && e.ColumnIndex == 0)
                {
                    e.PaintBackground(e.ClipBounds, false);
                    e.Handled = true;
                }
            }
        }
