            bool found = false;
            int nameCount = 1;
            if (dataGridView1 != null)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == fullName)
                    {
                        found = true;
                        row.Cells[1].Value = Convert.ToInt32(row.Cells[1].Value) + 1;
                    }
                }
                if (!found)
                {
                    dataGridView1.Rows.Add(new object[] { fullName, nameCount });
                }
            }
