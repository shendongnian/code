     private DataTable ToDataTable(List<Sale> SaleItems)
        {
            DataTable returnTable = new DataTable("Sale");
            returnTable.Columns.Add(new DataColumn("Name"));
            returnTable.Columns.Add(new DataColumn("#"));
            returnTable.Columns.Add(new DataColumn("B. Address"));
            returnTable.Columns.Add(new DataColumn("S. Address"));
            returnTable.Columns.Add(new DataColumn("Configurations"));
     
            foreach (Sale item in SaleItems)
            {
                returnTable.AcceptChanges();
                DataRow row = returnTable.NewRow();
                row[0] = item.product.name;
                row[1] = item.quantity.ToString();
                row[2] = item.billingAddress.ToString();
                row[3] = item.billingAddress.ToString();
                StringBuilder sbConfigurations = new StringBuilder();
    
                foreach (BuyingConfiguration configurationItem in item.product.buyingConfigurations) {
                   sbConfigurations.AppendFormat("{0}: {1}<br />", configurationItem.name, configurationItem.value);
                }
                row[4] = sbConfigurations.ToString();
    
                returnTable.Rows.Add(row);
            }
            return returnTable;
        }
