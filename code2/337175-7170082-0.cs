    U can compare like this also, 
    foreach (DataTable TblDefault in ds.Tables) \\ gridview values
    {
    foreach (DataTable Tbldefault1 in ds1.Tables) \\databasevalues
    {
    if (TblDefault.TableName.ToUpper().Trim() == Tbldefault1.TableName.ToUpper().Trim())
    {
    }
    }
    }
