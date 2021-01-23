    Table table = new Table();
    
    ColInfo[] cols = new ColInfo[4]; 
    cols.Add("year", "Year", "string");
    cols.Add("month", "Month", "string");  
    cols.Add("day", "Day", "string"); 
    cols.Add("count", "Count", "number"); 
    
    table.rows = cmsMembersWithCount.Select(row => new DataPointSet(){ 
    {new DataPoint(row.Year)} 
    {new DataPoint(row.Month)} 
    {new DataPoint(row.Day)} 
    {new DataPoint(row.Count)} 
    }).ToArray();
         
      
    var json = JsonConvert.SerializeObject(table);
