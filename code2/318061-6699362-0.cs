    private void UpdateDataGridViewColor()
        {
            if (calledMethod == 2)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    int j = 6;
                    DataGridViewCellStyle CellStyle = new DataGridViewCellStyle();
                    CellStyle.ForeColor = Color.Red;
                    if (isLate(dataGridView1[j, i].Value.ToString()))
                    {
                        dataGridView1[j, i].Style = CellStyle;
                    }
                }
            }
        }
