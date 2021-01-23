        private void Fill()
        {
            if (string.IsNullOrEmpty(CurrConnectionStr)) return;
            SelectedTable = TableComboBox.Text;
            if (string.IsNullOrEmpty(SelectedTable)) return;
            try
            {
                Globals.ThisAddIn.Application.Cells.ClearContents();
                var dataTable = new System.Data.DataTable(); 
                var query = string.Format(RowsQuery, SelectedTable);
                using (var sqlDataAdapter = new SqlDataAdapter(query, CurrConnectionStr))
                {
                    sqlDataAdapter.Fill(dataTable);
                }
                var excelApplicationObject = Globals.ThisAddIn.Application;
                int rowNumber = 1;
                foreach (System.Data.DataColumn column in dataTable.Columns)
                {
                    int columnNumber = dataTable.Columns.IndexOf(column) + 1;
                    excelApplicationObject.Cells[rowNumber, columnNumber].Value2 = column.ColumnName;
                }
                rowNumber += 1;
                foreach (System.Data.DataRow row in dataTable.Rows)
                {
                    excelApplicationObject
                        .Cells
                        .Range[
                            excelApplicationObject.Cells[rowNumber, 1], 
                            excelApplicationObject.Cells[rowNumber, row.ItemArray.Count()]]
                        .Value2 = row.ItemArray;
                    rowNumber++;
                }
                excelApplicationObject.Cells[rowNumber, 1] = "View Name: ";
                excelApplicationObject.Cells[rowNumber, 2] = SelectedTable;
                rowNumber += 1;
                excelApplicationObject.Cells[rowNumber, 1] = "Saved At:";
                excelApplicationObject.Cells[rowNumber, 2] = DateTime.Now.ToLongTimeString();
                rowNumber += 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
