csharp
AddDialog(new OAuthPrompt(
    nameof(OAuthPrompt),
    new OAuthPromptSettings
    {
        ConnectionName = ConnectionName,
        Text = "Please login",
        Title = "Login",
        Timeout = 300000, // User has 5 minutes to login
    }));
First step:
csharp
private async Task<DialogTurnResult> PromptStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
    return await stepContext.BeginDialogAsync(nameof(OAuthPrompt), null, cancellationToken);
}
Next step:
csharp
private async Task<DialogTurnResult> LoginStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
{
    // Get the token from the previous step. Note that we could also have gotten the
    // token directly from the prompt itself. There is an example of this in the next method.
    var tokenResponse = (TokenResponse)stepContext.Result;
    if (tokenResponse != null)
    {
        await stepContext.Context.SendActivityAsync(MessageFactory.Text("You are now logged in."), cancellationToken);
        return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions { Prompt = MessageFactory.Text("Would you like to do? (type 'me', 'send <EMAIL>' or 'recent')") }, cancellationToken);
    }
    await stepContext.Context.SendActivityAsync(MessageFactory.Text("Login was not successful please try again."), cancellationToken);
    return await stepContext.EndDialogAsync();
}
Now we have the token.
### Step 2
csharp
// Gets the user's photo
public async Task<PhotoResponse> GetPhotoAsync()
{
    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _token);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
    using (var response = await client.GetAsync("https://graph.microsoft.com/v1.0/me/photo/$value"))
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Graph returned an invalid success code: {response.StatusCode}");
        }
        var stream = await response.Content.ReadAsStreamAsync();
        var bytes = new byte[stream.Length];
        stream.Read(bytes, 0, (int)stream.Length);
        var photoResponse = new PhotoResponse
        {
            Bytes = bytes,
            ContentType = response.Content.Headers.ContentType?.ToString(),
        };
        if (photoResponse != null)
        {
            photoResponse.Base64String = $"data:{photoResponse.ContentType};base64," +
                                            Convert.ToBase64String(photoResponse.Bytes);
        }
        return photoResponse;
    }
}
### Step 3
csharp
public static string ImageToBase64()
{
    var path = System.Web.HttpContext.Current.Server.MapPath(@"~\imgs\testpic.PNG");
    Byte[] bytes = File.ReadAllBytes(path);
    string base64String = Convert.ToBase64String(bytes);
    return "data:image/png;base64," + base64String;
}
[...]
var imgUrl = ImageToBase64();
var cardImages = new List<CardImage>();
cardImages.Add(new CardImage(url: imgUrl));
var heroCard = new HeroCard
{
    Title = "BotFramework Hero Card",
    Subtitle = "Microsoft Bot Framework",
    Text = "Build and connect intelligent bots to interact with your users naturally wherever they are," +
            " from text/sms to Skype, Slack, Office 365 mail and other popular services.",
    Images = cardImages,
    Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Get Started", value: "https://docs.microsoft.com/bot-framework") },
};
var attachment = heroCard.ToAttachment();
var message = MessageFactory.Attachment(attachment);
await context.PostAsync(message);
