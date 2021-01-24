    var columnNames  = Enumerable.Range(0,200).Select(t=> "_"+t).ToArray();
    var properties typeof(MyTable).GetProperties()
    .Where(t=>columnNames.Contains(t.Name))
    .ToDictionary(t=> t.Name); // outside of the loop
    valmat = properties["_"+i].GetValue(result,null); //inside of the loop
