        private void UpdateSumRow()
        {
            // Get the last row.
            DataGridViewRow sumRow = dataGridView.Rows[dataGridView.Rows.Count - 1];
            decimal sumPrice = 0;
            int sumQuantity = 0;
            foreach (DataGridViewRow r in dataGridView.Rows)
            {
                sumPrice += (decimal)r.Cells[COL_PRICE].Value;
                sumQuantity += (int)r.Cells[COL_QUANTITY].Value;
            }
            sumRow.Cells[COL_PRICE].Value = sumPrice;
            sumRow.Cells[COL_QUANTITY].Value = sumQuantity;
        }
