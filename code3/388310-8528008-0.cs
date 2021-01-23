    try
    {
        response = crm.Execute(request);
    }
    catch (SoapException e)
    {
        //Console.Write(e.Detail.InnerXml);
        throw new Exception (e.Detail.InnerXml, e);
    }
