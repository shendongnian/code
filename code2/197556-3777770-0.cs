     List<string> lstContents = new List<string>();
            foreach (DataGridViewCell cell in mydataGrid.Rows[mydataGrid.RowCount - 1].Cells)
            {
                lstContents .Add((string)cell.Value);
            }
     string myData= string.Join(",", lstContents.ToArray());
