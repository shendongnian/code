        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e) => 
            dataGridView1.CurrentCell.Style.Format = "yyMMdd";
        private void DataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            DateTime.TryParseExact(dataGridView1.CurrentCell.EditedFormattedValue.ToString(), "yyMMdd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dateToSaveInDb);
            e.Value = dateToSaveInDb;
            e.ParsingApplied = true;
            dataGridView1.CurrentCell.Style.Format = "yy-MM-dd hh:mm:ss";
        }
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e) => 
            dataGridView1.CurrentCell.Style.Format = "yy-MM-dd hh:mm:ss";
        
