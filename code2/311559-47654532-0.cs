    var derivedType = Type.GetType(this.GetType().FullName);
    var FileStorage = derivedType.GetProperty("FileStorage", BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this) as byte[];
    if (FileStorage != null) 
    {
        ...
    }
