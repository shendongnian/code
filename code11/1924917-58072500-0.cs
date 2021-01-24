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
        [Route("api/notify/{userid?}")]
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
    
            public async Task<IActionResult> Post(string userid,[FromBody] NotifyMessage notifyMessage)
            {
                
                if (string.IsNullOrEmpty(userid))
                {
                    foreach (var conversationReference in _conversationReferences.Values)
                    {
                        await ((BotAdapter)_adapter).ContinueConversationAsync(_appId, conversationReference, (ITurnContext turnContext, CancellationToken cancellationToken) => turnContext.SendActivityAsync(notifyMessage.message), default(CancellationToken));
                    }
                }
                else {
                    _conversationReferences.TryGetValue(userid,out var conversationReference);
                    await ((BotAdapter)_adapter).ContinueConversationAsync(_appId, conversationReference, (ITurnContext turnContext, CancellationToken cancellationToken) => turnContext.SendActivityAsync(notifyMessage.message), default(CancellationToken));
                }
                
                
                // Let the caller know proactive messages have been sent
                return new ContentResult()
                {
                    Content = "<html><body><h1>Proactive messages have been sent:"+ userid + "</h1></body></html>",
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK,
                };
            }
            
        }
    
        public class NotifyMessage
        {
            public string message { get; set; }
    
        }
    }
