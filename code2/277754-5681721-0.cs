    try
    {
        formattedOutput = System.Xml.Linq.XElement.Parse(myHtmlString).ToString();
    }
    catch
    {
        // isn't well-formed xml
    }
