       namespace Microsoft.BotBuilderSamples
    {
        public static class DialogExtensions
        {
            public static async Task Run(this Dialog dialog, ITurnContext turnContext, IStatePropertyAccessor<DialogState> accessor, CancellationToken cancellationToken = default(CancellationToken))
            {
                
                var dialogSet = new DialogSet(accessor);
                dialogSet.Add(dialog);
    
    
                var dialogContext = await dialogSet.CreateContextAsync(turnContext, cancellationToken);
    
    
                if (dialogContext.Context.Activity.GetType().GetProperty("ChannelData") != null)
                {
                    var channelData = JObject.Parse(dialogContext.Context.Activity.ChannelData.ToString());
                     //Check property in teams channel
                    if (channelData.ContainsKey("source"))
                    {
                        var postbackActivity = dialogContext.Context.Activity;
                        // Convert the user's Adaptive Card input into the input of a Text Prompt
                        // Must be sent as a string
                        postbackActivity.Text = postbackActivity.Value.ToString();
                        
    
                    }
                }
                var results = await dialogContext.ContinueDialogAsync(cancellationToken);
                if (results.Status == DialogTurnStatus.Empty)
                {
                    await dialogContext.BeginDialogAsync(dialog.Id, null, cancellationToken);
                }
