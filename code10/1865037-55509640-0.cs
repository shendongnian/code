     var incomingContentType = System.ServiceModel.Web.WebOperationContext.Current.IncomingRequest.ContentType;
     var streamContent = new StreamContent(myFile);
     var incomingContentBody = streamContent.ReadAsStringAsync().Result;
     var client = new RestClient("yourApiRouteHere");
     var request = new RestRequest(Method.POST);
     request.AddHeader("cache-control", "no-cache");
     request.AddHeader("Authorization", "yourAuthHere");
     request.AddHeader("content-type", incomingContentType);
     request.AddParameter(incomingContentType, incomingContentBody, ParameterType.RequestBody);
     IRestResponse response = client.Execute(request);
     if (response.StatusCode == System.Net.HttpStatusCode.OK)
         return true;
