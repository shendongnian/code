      [HttpGet("{number}")]
            public async Task<IActionResult> Get(string number)
            {
    
                //For Twillio Channel
                MicrosoftAppCredentials.TrustServiceUrl("https://sms.botframework.com/");
    
                var NewConversation = new ConversationReference
                {
                    User = new ChannelAccount { Id = $"+1{number}" },
                    Bot = new ChannelAccount { Id = "+1YOURPHONENUMBERHERE" },
                    Conversation = new ConversationAccount { Id = $"+1{number}" },
                    ChannelId = "sms",
                    ServiceUrl = "https://sms.botframework.com/"
                };
    
                try
                {
                    BotAdapter ba = (BotAdapter)_HttpAdapter;
                    await ((BotAdapter)_HttpAdapter).ContinueConversationAsync(_AppId, NewConversation, BotCallback, default(CancellationToken));
                }
                catch (Exception ex)
                {
                    this._Logger.LogError(ex.Message);
                }
    
    
                // Let the caller know proactive messages have been sent
                return new ContentResult()
                {
                    Content = "<html><body><h1>Proactive messages have been sent.</h1></body></html>",
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK,
                };
            }
