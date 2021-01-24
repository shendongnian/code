    DataTable dt = new DataTable();            
            if (dgvPedidos.SelectedRows.Count > 0)
            {
                foreach (DataGridViewColumn column in dgvPedidos.Columns)
                    dt.Columns.Add();
                int i = 0;
                foreach(DataGridViewRow row in dgvPedidos.Rows)
                {
                    if (Convert.ToBoolean(dgvPedidos.Rows[i].Cells["chkPedido"].Value) == true)
                    {
                        dt.Rows.Add();
                        dt.Rows[i][1] = row.Cells[1].Value.ToString();
                        dt.Rows[i][2] = row.Cells[2].Value.ToString();
                        dt.Rows[i][3] = row.Cells[3].Value.ToString();
                        dt.Rows[i][4] = row.Cells[4].Value.ToString();
                        dt.Rows[i][5] = row.Cells[5].Value.ToString();
                        dt.Rows[i][6] = row.Cells[6].Value.ToString();
                        dt.Rows[i][7] = row.Cells[7].Value.ToString();
                        dt.Rows[i][8] = row.Cells[8].Value.ToString();
                        dt.Rows[i][9] = row.Cells[9].Value.ToString();
                        i++;
                    }
                }
                dt.Columns.RemoveAt(0);
