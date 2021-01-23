    queriable.Select(x=>x.MyColumn);
    //is translatable to sql when there is a column that is named MyColumn in your table
    
    queriable.Where(x=>x.MyColumn.Contains("X"))
    //is translatable to sql as "...where MyColumn like '%X%' ..."
    
    queriable.Select(x=> new { x.MyColumn, x.AnotherColumn})
    //is translatable to sql for selecting multiple columns
    
    queriable.Select(SelectProperties)
    //is not translatable to sql because it does not return an expression that selects a single value, and its not an expression that returns a new object.
