        private void RightMouseClick(TextBox txtBox)
        {
            int rowindex = dgvResults.CurrentCell.RowIndex;
            int columnindex = dgvResults.CurrentCell.ColumnIndex;
            if (string.IsNullOrEmpty(txtResult))
            {
                txtBox.Text = dgvResults.Rows[rowindex].Cells[columnindex].Value.ToString();
            }
            else
            {
                string selectedCell;
                double resultText;
                selectedCell = dgvResults.Rows[rowindex].Cells[columnindex].Value.ToString();
                resultaat = Convert.ToDouble(txtBox.Text) + Convert.ToDouble(selectedCell);
                txtBox.Text = Convert.ToString(resultText);
            }
        }
