    private void MyGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
            {
                if ((int)MyGridView.Rows[e.RowIndex].Cells[0].Value > 30)
                {
                    e.CellStyle.BackColor = System.Drawing.Color.Red;
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                }
            }
