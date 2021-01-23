        if (h.Name == "Authentication")
        {
            // Read the value of that header.
            XmlReader xr = OperationContext.Current.IncomingMessageHeaders.GetReaderAtHeader(i);
            //apiKey = xr.ReadElementContentAsString();
            XDocument xd = XDocument.Load(xr);
            apiKey = xd.Elements(x=>x.Name == XName.GetName("apiKey")).First().Text;
        }
