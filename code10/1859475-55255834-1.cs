    private void metroGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (this.metroGrid1.Columns[e.ColumnIndex].DataPropertyName == "Date 1")
        {
            try
            {
                int countDarkRed = 0;
                var EMIDate1 = Convert.ToDateTime(metroGrid1.Rows[e.RowIndex].Cells["date1DataGridViewTextBoxColumn"].Value);
                //Checking whether we have to turn it red or not
                if (EMIDate1 <= DateTime.Today)
                {
                    e.CellStyle.BackColor = Color.DarkRed;
                    e.CellStyle.ForeColor = Color.White;
                }
                //Checking how many cells have turned red
                foreach(DataGridViewRow row in this.metroGrid1.Rows)
                {
                    if (row.Cells["date1DataGridViewTextBoxColumn"].Style.BackColor == Color.DarkRed)
                    {
                        countDarkRed++;
                    }
                }
                labelEMI.Text = "Total EMI due as on today:" + countDarkRed;
            }
            catch
            {
            }
        }
    }
