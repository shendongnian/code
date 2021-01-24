ConfidentialClientApplication cca = new ConfidentialClientApplication(
    [client_id], [redirect_uri],
    new ClientCredential([secret]),
    new TokenCache(), null);
string[] scopes = new string[]
{
    "user.read",
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
reply.Body.ContentType = BodyType.Html;
reply.Body.Content = [html_code];
client
    .Me
    .Messages[reply.Id]
    .Request()
    .UpdateAsync(reply);
client
    .Me
    .Messages[reply.Id]
    .Send()
    .Request()
    .PostAsync()
    .Wait(); 
