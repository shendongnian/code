    using System;
    using System.Collections.Concurrent;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Builder.Integration.AspNet.Core;
    using Microsoft.Bot.Schema;
    using Microsoft.Extensions.Configuration;
    
    namespace ProactiveBot.Controllers
    {
        [Route("api/notify")]
        [ApiController]
        public class NotifyController : ControllerBase
        {
            private readonly IBotFrameworkHttpAdapter _adapter;
            private readonly string _appId;
            private readonly ConcurrentDictionary<string, ConversationReference> _conversationReferences;
        public NotifyController(IBotFrameworkHttpAdapter adapter, IConfiguration configuration, ConcurrentDictionary<string, ConversationReference> conversationReferences)
        {
            _adapter = adapter;
            _conversationReferences = conversationReferences;
            _appId = configuration["MicrosoftAppId"];
            // If the channel is the Emulator, and authentication is not in use,
            // the AppId will be null.  We generate a random AppId for this case only.
            // This is not required for production, since the AppId will have a value.
            if (string.IsNullOrEmpty(_appId))
            {
                _appId = Guid.NewGuid().ToString(); //if no AppId, use a random Guid
            }
        }
        public async Task<IActionResult> Get([FromQuery(Name = "taskID")] int taskID)
        {            
            foreach (var conversationReference in _conversationReferences.Values)
            {                
                
                await ((BotAdapter)_adapter).ContinueConversationAsync(_appId, conversationReference, async (context, token) => {
                    await context.SendActivityAsync("proactive task notification for TaskID: " + taskID.ToString());
                }, default(CancellationToken));
            }
          
            
            // Let the caller know proactive messages have been sent
            return new ContentResult()
            {
                Content = "<html><body><h1>Proactive messages have been sent.</h1><p>" + taskID.ToString() + "</p></body></html>",
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
            };
        }
    }
