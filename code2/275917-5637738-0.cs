    DataTable distinctTable = dTable.Clone();
    dTable.Columns.Add("ITEM_STOCK_D", typeof(Decimal),
                       "CONVERT(ITEM_STOCK, 'System.Decimal')");
    foreach (DataRow dRow in dTable.Rows)
    {
        String itemNo = dRow["ITEM_NO"].ToString();
        if(distinctTable.Select(String.Format("ITEM_NO = '{0}'",itemNo)).Length == 0)
        {
            double totalStock = Convert.ToDouble(dTable.Compute("SUM(ITEM_STOCK_D)",
                                         String.Format("ITEM_NO = '{0}'", itemNo))); 
            distinctTable.Rows.Add(itemNo, totalStock.ToString());
        }
    }
    dTable.Columns.Remove("ITEM_STOCK_D");
