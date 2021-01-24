csharp
if (dialogContext.Context.Activity.GetType().GetProperty("ChannelData") != null)
            {
                var channelData = JObject.Parse(dialogContext.Context.Activity.ChannelData.ToString());
                if (channelData.ContainsKey("postBack"))
                {
                    var postbackActivity = dialogContext.Context.Activity;
                    // Convert the user's Adaptive Card input into the input of a Text Prompt
                    // Must be sent as a string
                    postbackActivity.Text = postbackActivity.Value.ToString();
             await dialogContext.Context.SendActivityAsync(postbackActivity);
                }
            }
Basically, the reason this fails is because Emulator sends card input as a "postback", but other channels do not. However, ALL channels send it in `Activity.Value` while leaving `Activity.Text` blank, hence the code in `OnTurnAsync`. The reason that it's re-prompting is likely because in `Run`, you're telling it to send a message (`await dialogContext.Context.SendActivityAsync(postbackActivity);`), which messes up the flow of the dialog.
