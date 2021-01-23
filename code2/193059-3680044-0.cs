    var iterator = listArray.GetEnumerator();
    while(iterator.MoveNext())
    {
       var item = iterator.Current;
       Console.WriteLine(item);
    }
