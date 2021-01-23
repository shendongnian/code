    public MyObject GetMyObjectFromLog(IMyXmlReader reader)
    {
        var xmlData = reader.GetData();
        //make your object here
        var obj = new MyObject(xmlData);
        return obj;  
    }
