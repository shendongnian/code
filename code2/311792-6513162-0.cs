    public List<string> GetColumnHeaders(){
      List<string> columnList = new List<string>();
      using (SondesEntities context = new HBS_SondesEntities()){
        foreach (var r in context.Mapping.GetTables()){
           if (r.TableName
                 .Equals("table1", StringComparison.InvariantCultureIgnoreCase)) {
               foreach (var c in r.RowType.DataMembers){
                   columnList.Add(c.MappedName);
               }
           }
         }
      }
      return columnList;
    }
