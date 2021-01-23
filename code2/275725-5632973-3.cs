    public enum Types 
    {
        type1 = 0,
        type2 = 1,
        type3 = 2
    }
    public string FormatName(Types t) 
    {
        switch (t) 
        {
            case Types.type1:
                return "mytype1";
            case Types.type2:
                return "mytype2";
            case Types.type3:
                 return "mytype3";
            default:
                return string.Empty;
         }
    }
    var resultedAndFormatedDictionary = EnumToDictionary<Types>(FormatName);
