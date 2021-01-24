ConfidentialClientApplication cca = new ConfidentialClientApplication(
    [client_id], [redirect_uri],
    new ClientCredential([secret]),
    new TokenCache(), null);
string[] scopes = new string[]
{
    "mail.read",
    "mail.readwrite",
    "mail.send",
};
AuthenticationResult result = (cca as IByRefreshToken).AcquireTokenByRefreshTokenAsync(scopes, [refresh_token]).Result;
GraphServiceClient client = new GraphServiceClient(new DelegateAuthenticationProvider((requestMessage) =>
{
    requestMessage.Headers.Authorization = new
    AuthenticationHeaderValue("Bearer", result.AccessToken);
    return Task.FromResult(0);
}));
string id = [message_id];
Message reply = client
    .Me
    .Messages[id]
    .CreateReply()
    .Request()
    .PostAsync().Result; 
client
    .Me
    .Messages[reply.Id]
    .Request()
    .UpdateAsync(new Message() {
        Body = new ItemBody() {
            Content = msg.Body,
            ContentType = BodyType.Html 
        }
     })
    .Wait(); // You have to use a new object and define only the fields you want to change
client
    .Me
    .Messages[reply.Id]
    .Send()
    .Request()
    .PostAsync()
    .Wait(); 
