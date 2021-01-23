            for (int u = 0; u < dataGridView3.RowCount; u++)
            {
                if (dataGridView3.Rows[u].Cells[4].Value == "The filter string")
                {
                    dataGridView3.Rows[u].Visible = true;
                }
                else
                {
                    dataGridView3.Rows[u].Visible = false;
                }
            }
