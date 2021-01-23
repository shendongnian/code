    public List<string> GetColumnHeaders(){
      
        List<string> columnList = new List<string>();
        using (SondesEntities context = new HBS_SondesEntities()){
            var query = (
               context.Mapping.GetTables()
                 .Where(t=>t.TableName
                            .Equals(
                             "table1", 
                              StringComparison.InvariantCultureIgnoreCase)
                            )
                 ).SelectMany(x=>x.RowType.DataMembers);
    
            columnList  = query.Select(m=>m.MappedName).ToList()
        }
        return columnList;
    }
    
