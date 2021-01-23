    SqlDataAdapter da = new SqlDataAdapter(...);
    DataSet ds = new DataSet();
    DataTableMapping dtm1, dtm2, dtm3;
    dtm1 = da.TableMappings.Add("Table", "Employees"); 
    dtm2 = da.TableMappings.Add("Table1", "Products");
    dtm3 = da.TableMappings.Add("Table2", "Orders");
    da.Fill(ds);
