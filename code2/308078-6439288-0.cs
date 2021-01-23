    if (h.Name == "Authentication")
    {
      // Read the value of that header.
      XmlReader xr = OperationContext.Current.IncomingMessageHeaders.GetReaderAtHeader(i);
      xr.ReadToDescendant("apiKey");
      apiKey = xr.ReadElementContentAsString();
    }
