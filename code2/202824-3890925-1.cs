        REQUEST request = new REQUEST();
        request.ID = "1234";
        request.Type = REQUESTTypetype.One;
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        XmlSerializer xs = new XmlSerializer(typeof(REQUEST));
        xs.Serialize(sw, request);
        Console.WriteLine(sb.ToString());
