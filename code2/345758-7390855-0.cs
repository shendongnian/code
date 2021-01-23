    public void GetMinMaxRange<T>( DataTable data, string valueColumnName ) 
                                                                 where T : IComparable<T>
    {
       DataColumn column = data.Columns[valueColumnName];
       var min = data.AsEnumerable().Min(m => m.Field<T>(valueColumnName));
       var max = data.AsEnumerable().Max(m => m.Field<T>(valueColumnName));
    }
