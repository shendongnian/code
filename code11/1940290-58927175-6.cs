         public class CallerContext
        {
            public string awsSdkVersion { get; set; }
            public string clientId { get; set; }
        }
        public class UserAttributes
        {
            public string sub { get; set; }
            public string email_verified { get; set; }
            public string name { get; set; }
            public string phone_number_verified { get; set; }
            public string phone_number { get; set; }
            public string email { get; set; }
        }
        public class Request
        {
            public UserAttributes userAttributes { get; set; }
            public string codeParameter { get; set; } = "####";
            public string linkParameter { get; set; }
            public object usernameParameter { get; set; }
        }
        public class Response
        {
            public object smsMessage { get; set; }
            public object emailMessage { get; set; }
            public object emailSubject { get; set; }
        }
        public class RootObject
        {
            public string version { get; set; }
            public string region { get; set; }
            public string userPoolId { get; set; }
            public string userName { get; set; }
            public CallerContext callerContext { get; set; }
            public string triggerSource { get; set; }
            public Request request { get; set; }
            public Response response { get; set; }
        }
