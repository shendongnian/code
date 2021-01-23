    public void LogObject(object obj)
    {
        var serializer = new JavaScriptSerializer();
        var objString = serializer.Serialize(obj);
        WriteLog(objString);
    }
