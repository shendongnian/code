            AmazonApiGatewayManagementApiClient client = new AmazonApiGatewayManagementApiClient(new AmazonApiGatewayManagementApiConfig() {
                ServiceURL = "https://" + request.RequestContext.DomainName + "/" + request.RequestContext.Stage
            });
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(document)));
            PostToConnectionRequest postRequest = new PostToConnectionRequest()
            {
                ConnectionId = request.RequestContext.ConnectionId,
                Data = stream
            };
            var result = client.PostToConnectionAsync(postRequest);
            result.Wait();
