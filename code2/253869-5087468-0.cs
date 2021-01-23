    var objType = o.GetType();
    // get the ILookup<,> interface type (if the type implements it)
    var lookupInterface = type.GetInterface("System.Linq.ILookup`2");
    // the type implemented the interface if returned non-null value
    var isILookup = lookupInterface != null;
