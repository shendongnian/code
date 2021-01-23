    try
    {
        using (var stringWriter = new StringWriter())
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
            {
                ds.WriteObject(xmlWriter, objectToSerialize);
            }
            return stringWriter.ToString();
        }
    }
    catch (Exception ex)
    {
        return "cannot serialize '" + objectToSerialize + "' to xml : " + ex.Message;
    }
