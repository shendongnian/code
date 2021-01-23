    [WebMethod]
    [SoapHeader("Authentication")]
    [SoapHeader("unknownHeaders",Required=false)]
    public string TestService()
    {
       foreach (SoapUnknownHeader header in unknownHeaders) {
          // Test header
       }
    }
