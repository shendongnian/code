    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serviceUrl + "Add");
    using (Stream bodyStream = request.GetRequestStream())
    using (StreamWriter writer = new StreamWriter(bodyStream))
    {
        writer.Write("contractId: {0}", contractId);
        writer.Write("partners: {0}", String.Join(",", partners);
    }
    request.GetResponse();
