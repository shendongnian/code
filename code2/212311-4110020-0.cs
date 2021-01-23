    databaseConnection.Open();
    DataTable columns = databaseConnection.GetSchema(
                SqlClientMetaDataCollectionNames.Columns, restrictions);
    foreach (DataRow row in columns.Select("", "COLUMN_NAME"))
    {
        temp.Add(row["COLUMN_NAME"] as string);
    }
