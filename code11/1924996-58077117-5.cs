    object index = 1;
    object myIndexedObject = ic;
    Type myIndexType = index.GetType();
    var myIndexerProperty = myIndexedObject.GetType().GetProperties().FirstOrDefault(a =>
    {
        var p = a.GetIndexParameters();    
        return p.Length == 1 && p.FirstOrDefault(b => b.ParameterType == myIndexType) != null;
    });
    if (myIndexerProperty != null)
    {
        object myValue = myIndexerProperty.GetValue(myIndexecObject, new object[] { index });
        Console.WriteLine(myValue);
    }
