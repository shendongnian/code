    DataTable dt = myDataSet.myDataTable;
    dt.Columns.Add("MaxField1");
    
    EnumerableRowCollection<DataRow> qrySelectRecords =
              (from d in dt.Rows().AsEnumerable().OfType<DataRow>()
               where d.Field<DateTime>("readingDate") >= startDate 
                  && d.Field<DateTime>("readingDate") <= endDate
               let m = dt.AsEnumerable().Max(dr=>dr.Field<double>("field1"))
               select d.WithColumnSet("MaxField1", m));
    ...
    
    public static DataRow WithColumnSet(this DataRow input, string columnName, object value)
    {
        input[columnName] = value;
        return input;
    }
