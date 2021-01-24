    var patchCommands = new List<OnenotePatchContentCommand>();
    patchCommands.Add(new OnenotePatchContentCommand()
       {
            Target = "div:{72e378de-be4b-4633-86bc-8e136f9b3c2e}{107}",
            Action = OnenotePatchActionType.Append,
            Position = OnenotePatchInsertPosition.Before,
            Content = "<h1>Some content goes here...</h1>"
       });
            
    var request = graphClient.Me.Onenote.Pages[pageId].Content.Request();
    var message = new HttpRequestMessage(new HttpMethod("PATCH"), request.RequestUrl);
    message.Content = new StringContent(JsonConvert.SerializeObject(patchCommands), Encoding.UTF8, "application/json");
    await graphClient.AuthenticationProvider.AuthenticateRequestAsync(message);
    var response = await graphClient.HttpProvider.SendAsync(message);
