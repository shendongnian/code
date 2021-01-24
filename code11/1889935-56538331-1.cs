    public static string PrintMe(object obj)
    {
        string message = "";
        message += obj.GetType().GetProperty("AAAAA")?.GetValue(obj);  // this parameter is in both MyClass1 and MyClass2
        message += obj.GetType().GetProperty("BBBBB")?.GetValue(obj);    // this parameter is in both MyClass1 and MyClass2
        return message;
    }
