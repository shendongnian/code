    public static XmlDocument Serialize(ServiceFault toSer)
    {
        DataContractSerializer ser = new DataContractSerializer(toSer.GetType());
        XmlDocument tmp = new XmlDocument();
        using (MemoryStream mem = new MemoryStream())
        {
            using (var memWriter = XmlWriter.Create(mem))
            {
                ser.WriteObject(memWriter, toSer);
            }
            mem.Seek(0, SeekOrigin.Begin);
            tmp.Load(mem);
        }
        return tmp;
    }
