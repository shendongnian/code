        private void button1_Click(object sender, EventArgs e)
        {
            // Iterate through each of the rows.
            for (int i = 0; i < dgv.RowCount - 1; i++)
            {
                if (dgv.Rows[i].Cells[0].Value.ToString() == "bob")
                {
                    // Here is the trick.
                    var btnCell = new DataGridViewButtonCell();
                    dgv.Rows[i].Cells[1] = btnCell;
                }
            }
        }
