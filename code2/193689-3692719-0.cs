    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                switch (dataGridView1.Columns[e.ColumnIndex].DataPropertyName)
                {
                    case "Description":
                        {
                            break;
                        }
                    case "NormalRoom":
                        {
                            break;
                        }
                    case "Colour1":
                    case "Colour2":
                        {
                            Color co = Color.White;
                            if (e.Value != null && e.Value != DBNull.Value)
                            {
                                co = string2Color((string)e.Value);
                            }
                            e.CellStyle.BackColor = Color.White;
                            e.CellStyle.ForeColor = Color.Black;
