    object index = 1;
    object myIndexedObject = ic;
    Type myIndexType = index.GetType();
    var myIndexerProperty = myIndexedObject.GetType().GetProperties().FirstOrDefault(a =>
    {
        var p = a.GetIndexParameters();    
        
        // this will choose the indexer with 1 key 
        // <<public object this[int key]>>, 
        // - of the EXACT type:
        return p.Length == 1 
            && p.FirstOrDefault(b => b.ParameterType == myIndexType) != null;
        // notice that if you call the code below instead,
        // then the <<public object this[object key]>> indexer 
        // will be chosen instead, as it is first in the class,
        // and an <<int>> is an <<object>>
        //return p.Length == 1 
        //    && p.FirstOrDefault(b => b.ParameterType.IsAssignableFrom(myIndexType)) != null;
    });
    if (myIndexerProperty != null)
    {
        object myValue = myIndexerProperty
            .GetValue(myIndexedObject, new object[] { index });
        Console.WriteLine(myValue);
    }
