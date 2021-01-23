    object[] parameters = ....;
    HashSet<Type> types = new HashSet<Type>();
    foreach(object p in parameters)
    {
    	if (p != null)
    	{
    	  CollectTypes(p.GetType(), types)
    	}
    }
    
    var sr = new DataContractJsonSerializer(typeof(XmlRequest), types.ToArray());
