    using System;
    using System.IO;
    namespace Twilio.Controllers
    {
        public class SmsController : TwilioController
        {
            public TwiMLResult Index(SmsRequest incomingMessage)
            {
                var messagingResponse = new MessagingResponse();
                messagingResponse.Message("The copy cat says: " +
                                            incomingMessage.Body);
                Console.WriteLine(incomingMessage.Body);
                           
                using (StreamWriter w = File.AppendText("log.txt"))
                {
                    Log(incomingMessage.Body, w);
                }
                return TwiML(messagingResponse); 
            }
            public static void Log(string logMessage, TextWriter w)
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                w.WriteLine("  :");
                w.WriteLine($"  :{logMessage}");
                w.WriteLine ("-------------------------------");
            }
        }
    }
