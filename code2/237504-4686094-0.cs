    private static void Test()
    {
        var r1 = TryParse("23", typeof(int));
        var r2 = TryParse("true", typeof(bool));
    }
    private static bool TryParse(string valueToParse, Type type)
    {
        //there are more then one TryParse method and we need the one with 2 parameters
        var method = type.GetMethods().Where(m => m.Name == "TryParse" && m.GetParameters().Count() == 2).Single();
        var instance = Activator.CreateInstance(type); //create instance of the type
        var result = method.Invoke(null, new object[] { valueToParse, instance });
        return (bool)result;
    }
    
