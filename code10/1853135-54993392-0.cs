    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        if (activity.Type == ActivityTypes.Message)
        {
            //retrieve the option value before processing the message
            string optionValue = string.Empty;
            using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
            {
                var botData = scope.Resolve<IBotData>();
                await botData.LoadAsync(CancellationToken.None);
                optionValue = botData.PrivateConversationData.GetValue<string>("option");
            }
    
            await Conversation.SendAsync(activity, () => new ParameterizedRootDialog(optionValue));
    
        }
        else if (activity.Type == ActivityTypes.Event)
        {
            var eventActivity = activity.AsEventActivity();
            if (string.Equals(eventActivity.Name, "option", StringComparison.InvariantCultureIgnoreCase))
            {
                //save the option into PrivateConversationData
                string optionValue = eventActivity.Value.ToString();
                using (var scope = DialogModule.BeginLifetimeScope(Conversation.Container, activity))
                {
                    var botData = scope.Resolve<IBotData>();
                    await botData.LoadAsync(CancellationToken.None);
                    botData.PrivateConversationData.SetValue("option", optionValue);
                    await botData.FlushAsync(CancellationToken.None);
                }                    
            }
        }
    
        return Request.CreateResponse(HttpStatusCode.OK);
    }
