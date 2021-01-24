    private void dataGridView1_CellFormatting(object sender,
                                              DataGridViewCellFormattingEventArgs e)
    {
        DataGridViewRow row = DGV_boiteReception.Rows[e.RowIndex];
        if (row.Cells[0].Value != null )
        {
            e.CellStyle.Font = new Font(DGV_boiteReception.Font,
                    row.Cells[0].Value.ToString() == "False" ? 
                                                     FontStyle.Bold : FontStyle.Regular);
        }
    }
