         private DataTable rangeTable(Excel.Range range)
        {
            DataTable dataTable = new DataTable();
            int rowCnt = range.Rows.Count;
            int colCnt = range.Columns.Count;
            for (int i = 1; i <= rowCnt; i++)
            {
                DataRow newRow = dataTable.NewRow();
                for (int j = 1; j <= colCnt; j++)
                {
                    if (i == 1)
                    {
                        dataTable.Columns.Add(((Excel.Range)range.get_Item(i, j)).Value2.ToString(), typeof(string));
                    }
                    else
                    {
                        newRow[j - 1] = ((Excel.Range)range.get_Item(i, j)).Value2;
                    }
                }
                if (i > 1)
                {
                    dataTable.Rows.Add(newRow);
                }
            }
            return dataTable;
        }
