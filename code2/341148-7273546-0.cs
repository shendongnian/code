    static public Organization Copy(Organization org)
    {
        MemoryStream stream1 = new MemoryStream();
        //Serialize the Record object to a memory stream using DataContractSerializer.
        DataContractSerializer serializer = new DataContractSerializer(typeof(Organization));
        serializer.WriteObject(stream1, org);
        stream1.Position = 0;
        //Deserialize the Record object back into a new record object.
        Organization orgCopy = (Organization)serializer.ReadObject(stream1);
        return orgCopy;
    }
    static public T Copy<T>(T obj)
    {
        MemoryStream stream1 = new MemoryStream();
        //Serialize the Record object to a memory stream using DataContractSerializer.
        DataContractSerializer serializer = new DataContractSerializer(typeof(T));
        serializer.WriteObject(stream1, obj);
        stream1.Position = 0;
        //Deserialize the Record object back into a new record object.
        T objCopy = (T)serializer.ReadObject(stream1);
        return objCopy;
    }
