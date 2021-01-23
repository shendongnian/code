    public string ToXmlString(OuterClass AssetsWrapper)
    {
        XmlSerializer ser = new XmlSerializer(typeof(OuterClass));            
        MemoryStream memStream = new MemoryStream();
    
        // Convert object -> stream -> byte[] -> string (whew!)
        ser.WriteObject(memStream, AssetsWrapper);
        byte[] AssetsWrapperByte = memStream.ToArray();
        return Encoding.UTF8.GetString(AssetsWrapperByte);
    }
