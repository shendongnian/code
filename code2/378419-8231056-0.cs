        for (int i = 0; i < dataTable.Rows.Count; i++)
        {
            DataRow myRow = dataTable.Rows[i];
            for (int j = 0; j < dataTable.Columns.Count; j++)
            {
                if (dataTable.Columns[j].ColumnName.IndexOf("Total Price") > 0)
                {
                    AddProductPrice(SKU, myRow.ItemArray[j], j);
                }
                else if (dataTable.Columns[j].ColumnName.IndexOf("National Selling") > 0)
                {
                    AddProductPrice(SKU, myRow.ItemArray[j], 16); //
                }
            }
        }
