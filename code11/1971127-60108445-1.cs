        class Program
        {
            static void Main(string[] args)
            {
                ServiceReference1.ServiceClient client = new ServiceClient();
                using (new OperationContextScope(client.InnerChannel))
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.FirstName = "John";
                    userInfo.LastName = "Doe";
                    MessageHeader aMessageHeader = MessageHeader.CreateHeader("UserInfo", "http://tempuri.org", userInfo);
                    MessageHeader bheader = MessageHeader.CreateHeader("messageId", "http://www.company.com/foo/bar/soap/features/messageId/", "urn:uuid:123c155c-3ab4-19ca-a045-02003b1bb7f5");
               OperationContext.Current.OutgoingMessageHeaders.Add(aMessageHeader);
                    OperationContext.Current.OutgoingMessageHeaders.Add(bheader);
                    var result = client.Test();
                    Console.WriteLine(result);
                }
            }
        }
        public class UserInfo
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
    }
