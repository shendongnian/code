    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Color c = Color.Black;
            if (e.ColumnIndex == 6)
            {
                if (isLate(Convert.ToString(e.Value)))
                    c = Color.Red;
            }
            e.CellStyle.ForeColor = c; // or e.CellStyle.BackColor= c; whatever you can do like this
        }
