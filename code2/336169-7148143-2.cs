    var enumerable = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    
    int range = 2;
    int index = 10;
    
    enumerable.Skip(index-range).Take(range)
    .Union(enumerable.Skip(index).Take(1))
    .Union(
    	enumerable.Skip(index+1).Take(range)
    ).Dump();
