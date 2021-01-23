    public string ObjectToXML(object input)
    {
        try
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(input.GetType());
            serializer.Serialize(stringwriter, input);
            return stringwriter.ToString();
        }
        catch (Exception ex)
        {
            if (ex.InnerException != null)
                ex = ex.InnerException;
            return "Could not convert: " + ex.Message;
        }
    }
    //Usage
    var res = ObjectToXML(obj)
