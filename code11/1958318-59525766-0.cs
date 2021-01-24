    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Schema;
    using Microsoft.Bot.Builder.Azure;
    using System.Linq;
    
    namespace Microsoft.BotBuilderSamples.Bots
    {
        public class EchoBot : ActivityHandler
        {
            private static readonly AzureBlobStorage _myStorage = new AzureBlobStorage("XXX", "mybotuserlogs");
            // Create local Memory Storage.
            //private static readonly MemoryStorage _myStorage = new MemoryStorage();
    
            // Create cancellation token (used by Async Write operation).
            public CancellationToken cancellationToken { get; private set; }
    
            // Class for storing a log of utterances (text of messages) as a list.
            public class UtteranceLog : IStoreItem
            {
                // A list of things that users have said to the bot
                public List<string> UtteranceList { get; } = new List<string>();
    
                // The number of conversational turns that have occurred        
                public int TurnNumber { get; set; } = 0;
    
                // Create concurrency control where this is used.
                public string ETag { get; set; } = "*";
            }
    
            // Echo back user input.
            protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
            {
                // preserve user input.
                var utterance = turnContext.Activity.Text;
                // make empty local logitems list.
                UtteranceLog logItems = null;
    
                // see if there are previous messages saved in storage.
                try
                {
                    string[] utteranceList = { "UtteranceLog" };
                    logItems = _myStorage.ReadAsync<UtteranceLog>(utteranceList).Result?.FirstOrDefault().Value;
                }
                catch
                {
                    // Inform the user an error occured.
                    await turnContext.SendActivityAsync("Sorry, something went wrong reading your stored messages!");
                }
    
                // If no stored messages were found, create and store a new entry.
                if (logItems is null)
                {
                    // add the current utterance to a new object.
                    logItems = new UtteranceLog();
                    logItems.UtteranceList.Add(utterance);
                    // set initial turn counter to 1.
                    logItems.TurnNumber++;
    
                    // Show user new user message.
                    await turnContext.SendActivityAsync($"{logItems.TurnNumber}: The list is now: {string.Join(", ", logItems.UtteranceList)}");
    
                    // Create Dictionary object to hold received user messages.
                    var changes = new Dictionary<string, object>();
                    {
                        changes.Add("UtteranceLog", logItems);
                    }
                    try
                    {
                        // Save the user message to your Storage.
                        await _myStorage.WriteAsync(changes, cancellationToken);
                    }
                    catch
                    {
                        // Inform the user an error occured.
                        await turnContext.SendActivityAsync("Sorry, something went wrong storing your message!");
                    }
                }
                // Else, our Storage already contained saved user messages, add new one to the list.
                else
                {
                    // add new message to list of messages to display.
                    logItems.UtteranceList.Add(utterance);
                    // increment turn counter.
                    logItems.TurnNumber++;
    
                    // show user new list of saved messages.
                    await turnContext.SendActivityAsync($"{logItems.TurnNumber}: The list is now: {string.Join(", ", logItems.UtteranceList)}");
    
                    // Create Dictionary object to hold new list of messages.
                    var changes = new Dictionary<string, object>();
                    {
                        changes.Add("UtteranceLog", logItems);
                    };
    
                    try
                    {
                        // Save new list to your Storage.
                        await _myStorage.WriteAsync(changes, cancellationToken);
                    }
                    catch
                    {
                        // Inform the user an error occured.
                        await turnContext.SendActivityAsync("Sorry, something went wrong storing your message!");
                    }
                }
    
            }
        }
    }
       
