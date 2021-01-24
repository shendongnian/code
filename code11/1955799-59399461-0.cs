public class dWebHook: IDisposable
    {
        private readonly WebClient dWebClient;
        private static NameValueCollection discord = new NameValueCollection();
        public string WebHook { get; set;}
        public string UserName { get; set; }
        public string ProfilePicture { get; set;}
        public dWebHook()
        {
            dWebClient = new WebClient();
        }
      
        public void SendMessage(string msgSend)
        {
            discord.Add("username", UserName);
            discord.Add("avatar_url", ProfilePicture);
            discord.Add("content", msgSend);
            dWebClient.UploadValues(WebHook, discord);
        }
        public void Dispose()
        {
            dWebClient.Dispose();
        }
I think this is what you are looking for
