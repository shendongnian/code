     public class CosmosTranscriptStore : ITranscriptLogger
        {
          ...
            public async Task LogActivityAsync(IActivity activity)
            {
                ...
                    document.Add(activity.Conversation.Id, data);
                    await chatStorage.WriteAsync(document, new CancellationToken());
                
            }
        }
