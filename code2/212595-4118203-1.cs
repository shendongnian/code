    public static class Extensions
    {    
      public static IEnumerable<dynamic> AsDynamic (this DataTable dt)
      {
        foreach (DataRow row in dt.Rows) yield return row.AsDynamic();
      }
    
      public static dynamic AsDynamic (this DataRow row)
      {
        return new DynamicDataRow (row);
      }
      
      class DynamicDataRow : DynamicObject
      {
        DataRow _row;
        public DynamicDataRow (DataRow row) { _row = row; }
    
        public override bool TryGetMember (GetMemberBinder binder, out object result)
        {
          result = _row[binder.Name];
          return true;
        }
    
        public override bool TrySetMember (SetMemberBinder binder, object value)
        {
          _row[binder.Name] = value;
          return true;
        }
        
        public override IEnumerable<string> GetDynamicMemberNames()
        {	
            return _row.Table.Columns.Cast<DataColumn>().Select (dc => dc.ColumnName);
        }
      }
    }
