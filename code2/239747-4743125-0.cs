    foreach (DataRow r in dsproduct.Tables["loadUniqueProducts"].Rows)
    {
        int productID = r.Field<System.Int32>("ProductID");
        string productExpression = "ProductID=" + productID.ToString();
        string salesExpression = productExpression + " AND RowID=1";
        int? monthSales = r.Field<System.Int32?>("MonthSales");
        if ((monthSales.HasValue) && (monthSales.Value > 0))
        {
            DataRow[] selectedRows = dsproduct.Tables["MainTable"].Select(salesExpression);
            DataRow destRow;
            if (selectedRows.Length > 1)
                throw new Exception(String.Format("MainTable has ProductID {0} duplicate Sales RowID 1.", productID));
            else if (selectedRows.Length == 1)
                destRow = selectedRows[0];
            else
            {
                destRow = destTable.NewRow();
                destRow.SetField<System.Int32>("RowID", 1);
                destRow.SetField<System.Int32>("ProductID", productID);
                destTable.Rows.Add(destRow);
            }
            string locColumn = "Loc" + r.Field<System.Char>("Loc");
            destRow.SetField<System.Int32>(locColumn, monthSales.Value);
        }
