     public class AccessControlHandler : IHandleMessages<IMessage>
    {
        public IBus Bus { get; set; }
        public void Handle(IMessage message)
        {
            IDictionary<string, string> headers = Bus.CurrentMessageContext.Headers;
            string token;
            if (headers.TryGetValue("access_token", out token))
            {
                if (token == "MY_SECRET")
                {
                    Console.WriteLine("User authenticated");
                    return;
                }
            }
            Console.WriteLine("User not authenticated");
            Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
        }
