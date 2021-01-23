    var interface = destType.GetInterface(typeof(IList<>).Name);
    var destList = destObject as IList;
    // make sure that the destination is both IList and IList<T>
    if (interface != null && destList != null)
    {
        Type itemsType = interface.GetGenericArguments()[0];
        foreach (XmlNode xmlChildNode in xmlNode.Nodes) 
        { 
            object retObject = Deserialize(itemsType, xmlNode); 
            destList.Add(retObject); 
        } 
    } 
