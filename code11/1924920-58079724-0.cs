    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Bot.Builder;
    using Microsoft.Bot.Builder.Integration.AspNet.Core;
    using Microsoft.Bot.Schema;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    
    namespace Guyde.Controllers
    {
        [Route("api/notify")]
        [ApiController]
        public class NotifyController : ControllerBase
        {
            private readonly IBotFrameworkHttpAdapter _adapter;
            private readonly string _appId;
    
            public NotifyController(IBotFrameworkHttpAdapter adapter, IConfiguration configuration)
            {
                _adapter = adapter;
                _appId = configuration["MicrosoftAppId"];
    
                // If the channel is the Emulator, and authentication is not in use,
                // the AppId will be null.  We generate a random AppId for this case only.
                // This is not required for production, since the AppId will have a value.
                if (string.IsNullOrEmpty(_appId))
                {
                    _appId = Guid.NewGuid().ToString(); //if no AppId, use a random Guid
                }
            }
    
            public async Task<IActionResult> Post([FromBody] RootObject payload)
            {
    
                var message = payload.message;
    
                var json = JsonConvert.SerializeObject(payload.reference);
                ConversationReference reference = JsonConvert.DeserializeObject<ConversationReference>(json);
    
                await ((BotAdapter)_adapter).ContinueConversationAsync(_appId, reference, (ITurnContext turnContext, CancellationToken cancellationToken) => turnContext.SendActivityAsync(message), default(CancellationToken));
    
    
    
                // Let the caller know proactive messages have been sent
                return new ContentResult()
                {
                    Content = "<html><body><h1>Proactive messages have been sent</h1></body></html>",
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK,
                };
            }
    
        }
    
    
        public class User
        {
            public string id { get; set; }
            public string name { get; set; }
            public object aadObjectId { get; set; }
            public object role { get; set; }
        }
    
        public class Bot
        {
            public string id { get; set; }
            public string name { get; set; }
            public object aadObjectId { get; set; }
            public string role { get; set; }
        }
    
        public class Conversation
        {
            public object isGroup { get; set; }
            public object conversationType { get; set; }
            public string id { get; set; }
            public object name { get; set; }
            public object aadObjectId { get; set; }
            public object role { get; set; }
            public object tenantId { get; set; }
        }
    
        public class Reference
        {
            public string activityId { get; set; }
            public User user { get; set; }
            public Bot bot { get; set; }
            public Conversation conversation { get; set; }
            public string channelId { get; set; }
            public string serviceUrl { get; set; }
        }
    
        public class RootObject
        {
            public string message { get; set; }
            public Reference reference { get; set; }
        }
    }
