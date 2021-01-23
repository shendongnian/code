    private void GetXML(Name n)
    {
        var xmlsr=new XmlSerialize(typeof(Name));
        var ms=new MemoryStream();
        var tr = new XmlTextWriter(ms,Encoding.Unicode);
        xmlsr.Serialize(tr,n);
        var sb=new StringBuilder(Encoding.Unicode.GetString(ms.ToArray()));
        Console.WriteLine(sb.ToString());//xml for object n
    }
