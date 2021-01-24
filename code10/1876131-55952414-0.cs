    class Record
    {
       public string cislo;
       public string zprava;
       public string id;
       public string recDate;
    }
    .....
    List<Record> records = new List<Record>();
        XmlNodeList number = doc.GetElementsByTagName("SenderNumber");
        for (int i = 0; i < number.Count; i++)
        {
           records.Add(new Record { cislo = number[i].InnerXml });
        }
        XmlNodeList text = doc.GetElementsByTagName("TextDecoded");
        for (int i = 0; i < text.Count; i++)
        {
            records[i].zprava = text[i].InnerXml;
        }
