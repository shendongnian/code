    //To populate an existing variable we will do so, we will create a variable with the pre existing data
    object PrevData = YourVariableData;
    //After this we will map the json received
    var NewObj = JsonSerializer.Parse<T>(jsonstring);
    CopyValues(NewObj, PrevData)
    //I found a function that does what you need, you can use it
    //source: https://stackoverflow.com/questions/8702603/merging-two-objects-in-c-sharp
    public void CopyValues<T>(T target, T source)
    {
        Type t = typeof(T);
    
        
        var properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(prop => prop.CanRead && prop.CanWrite && prop.GetIndexParameters().Length == 0);
    
        foreach (var prop in properties)
        {
            var value = prop.GetValue(source, null);
            prop.SetValue(target, value, null);
        }
    }
