      [WebInvoke(UriTemplate = "/client/PostToclient", Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped)]
      [OperationContract]
       public async Task<string> PostToclient(string clientData, string username, string Id, string clientType)
       {
	   // Create / update client data.
       }
