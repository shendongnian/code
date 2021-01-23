     DataTable dtQtyData = new DataTable();
            dtQtyData.Clear();
            dtQtyData.Columns.Add("Id", typeof(int));
        dtQtyData.Columns.Add("ProductId", typeof(int));
        dtQtyData.Columns.Add("ShippingMethodId", typeof(int));
        dtQtyData.Columns.Add("ParentProductId", typeof(int));
        for (int i = 0; i < ShippingMethodIds.Length; i++)
        {
            for (int j = 0; j < ProductIds.Length; j++)
            {
                var productId = ProductIds[j];
                var shippingMethodId = ShippingMethodIds[i];
                dtQtyData.Rows.Add(new object[] {0,productId, shippingMethodId, parentProductId });
            }
           
        }
        var connectionString = new DataSettingsManager().LoadSettings().DataConnectionString;
        SqlBulkCopy bulkcopy = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.Default);
        bulkcopy.DestinationTableName = "ProductShippingMethodMap";
        bulkcopy.WriteToServer(dtQtyData);
