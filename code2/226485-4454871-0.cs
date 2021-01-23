    using (DataContext context = new DataContext(SqlConnection)
    {
        var custInfo = context.GetTable<tbl_CustomerInfo>();
    
        string compID = ImportCust.Rows[0]["CompanyID"].ToString();
    
        var imports = from cust in ImportCust.AsEnumerable()
                      select cust.Field<int>("CustomerID");
    
        var dupes = from import in imports
                    join cust in custInfo
                    on import equals cust.CustomerID 
                    where cust.CompanyID== pivnum
                    select cust;
    
        var records = dupes.GetEnumerator();
        while (records.MoveNext())
        { custInfo.DeleteOnSubmit(records.Current); }
    
        context.SubmitChanges();
    }
