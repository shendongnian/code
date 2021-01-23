        if (h.Name == "Authentication")
        {
            // Read the value of that header.
            XmlReader xr = OperationContext.Current.IncomingMessageHeaders.GetReaderAtHeader(i);
            //apiKey = xr.ReadElementContentAsString();
            xr.ReadToFollowing("Authentication");
            apiKey = xr.ReadElementContentAsString();
        }
