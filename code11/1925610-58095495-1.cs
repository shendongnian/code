    // this will return list of DB Objects
    var result = database.s.Where(x => x.DbColumn == param);
    
    // This will return only one:
    
    var result = database.s.FirstOrDefault(x => x.DbColumn == param);
    
    // Then you can get the value you need (e.g. the string column)
    if(result != null)
    var myStringColumn = result.MyStringColumn;
