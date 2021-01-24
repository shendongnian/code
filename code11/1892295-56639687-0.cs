    //1. construct a Batch request 
    var batchRequestContent = new BatchRequestContent();
    var step = 1;
    foreach (var eventId in eventIds)
    {
         var requestUrl = graphClient
               .Me
               .Events[eventId]
               .Request().RequestUrl;
                        
         var request = new HttpRequestMessage(HttpMethod.Delete, requestUrl);
         var requestStep = new BatchRequestStep(step.ToString(), request, null);
         batchRequestContent.AddBatchRequestStep(requestStep);
         step++;
    }
                
                
    //2. Submit request
    var batchRequest = new HttpRequestMessage(HttpMethod.Post, "https://graph.microsoft.com/v1.0/$batch");
    batchRequest.Content = batchRequestContent;
    await graphClient.AuthenticationProvider.AuthenticateRequestAsync(batchRequest);
    var httpClient = new HttpClient();
    var batchResponse = await httpClient.SendAsync(batchRequest);
    //3. Process response
    var batchResponseContent = new BatchResponseContent(batchResponse);
    var responses = await batchResponseContent.GetResponsesAsync();
    foreach (var response in responses)
    {
         if (response.Value.IsSuccessStatusCode)
         {
             //...
         }                 
    }
