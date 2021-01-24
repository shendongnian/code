csharp
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Schema;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace QuickTestBot_CSharp
{
    public class CosmosTranscriptStore : ITranscriptLogger
    {
        private CosmosDbStorage _storage;
        public CosmosTranscriptStore(CosmosDbStorageOptions config)
        {
            _storage = new CosmosDbStorage(config);
        }
        public async Task LogActivityAsync(IActivity activity)
        {
            // activity only contains Text if this is a message
            var isMessage = activity.AsMessageActivity() != null ? true : false;
            if (isMessage)
            {
                // Customize this to save whatever data you want
                var data = new
                {
                    From = activity.From,
                    To = activity.Recipient,
                    Text = activity.AsMessageActivity().Text,
                };
                var document = new Dictionary<string, object>();
                // activity.Id is being used as the Cosmos Document Id
                document.Add(activity.Id, data);
                await _storage.WriteAsync(document, new CancellationToken());
            }
        }
    }
}
### Create and Add the Middleware (in Startup.cs)
csharp
[...]
var config = new CosmosDbStorageOptions
{
    AuthKey = "<YourAuthKey>",
    CollectionId = "<whateverYouWant>",
    CosmosDBEndpoint = new Uri("https://<YourEndpoint>.documents.azure.com:443"),
    DatabaseId = "<whateverYouWant>",
};
var transcriptMiddleware = new TranscriptLoggerMiddleware(new CosmosTranscriptStore(config));
var middleware = options.Middleware;
middleware.Add(transcriptMiddleware);
[...]
### Result:
[![enter image description here][1]][1]
[![enter image description here][2]][2]
### Note:
This is probably the easiest/best way to do it. However, you can also capture outgoing activities under `OnTurnAsync()` using `turnContext.OnSendActivities()` and then write the outgoing activity to storage, as well.
  [1]: https://i.stack.imgur.com/UcED7.png
  [2]: https://i.stack.imgur.com/gbv6N.png
