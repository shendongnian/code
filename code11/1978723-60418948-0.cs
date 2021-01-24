    using Twilio.AspNet.Common;
    using Twilio.AspNet.Core;
    using Twilio.TwiML;
    
    namespace TwilioReceive.Controllers
    {
        public class SmsController : TwilioController
        {
            public TwiMLResult Index(SmsRequest incomingMessage)
            {
                var messagingResponse = new MessagingResponse();
                messagingResponse.Message("The copy cat says: " +
                                          incomingMessage.Body);
    
                return TwiML(messagingResponse);
            }
        }
    }
