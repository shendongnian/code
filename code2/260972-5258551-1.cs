    var usingMethodGroup = selectedTables.Where(table1.IsChildOf);
    var usingLambda = selectedTables.Where(x => table1.IsChildOf(x));
    table1 = null;
    // Fine: the *value* of `table1` was used to create the delegate
    Console.WriteLine(usingMethodGroup.Count());
    // Bang! The lambda expression will try to call IsChildOf on a null reference
    Console.WriteLine(usingLambda.Count());
