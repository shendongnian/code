     public abstract class BaseOAuthRepository
    {
        private static string REQUEST_URL = "https://etws.etrade.com/oauth/request_token";
        private static string AUTHORIZE_URL = "https://us.etrade.com/e/t/etws/authorize";
        private static string ACCESS_URL = "https://etws.etrade.com/oauth/access_token";
        private readonly TokenBase _tokenBase;
        private readonly string _consumerSecret;
   
        protected BaseOAuthRepository(TokenBase tokenBase, 
                                      string consumerSecret)
        {
            _tokenBase = tokenBase;
            _consumerSecret = consumerSecret;
        }
        public TokenBase MyTokenBase
        {
            get { return _tokenBase; }
        }
        public string MyConsumerSecret
        {
            get { return _consumerSecret; }
        }
     
        public OAuthSession CreateSession()
        {
            var consumerContext = new OAuthConsumerContext
            {
                ConsumerKey = MyTokenBase.ConsumerKey,
                ConsumerSecret = MyConsumerSecret,
                SignatureMethod = SignatureMethod.HmacSha1,
                UseHeaderForOAuthParameters = true,
                CallBack = "oob"
            };
            var session = new OAuthSession(consumerContext, REQUEST_URL, AUTHORIZE_URL, ACCESS_URL);	
            return session;
        }
        public IToken GetAccessToken(OAuthSession session)
        {
            IToken requestToken = session.GetRequestToken();
            string authorizationLink = session.GetUserAuthorizationUrlForToken(MyTokenBase.ConsumerKey, requestToken);
            Process.Start(authorizationLink);
            Console.Write("Please enter pin from browser: ");
            string pin = Console.ReadLine();
            IToken accessToken = session.ExchangeRequestTokenForAccessToken(requestToken, pin.ToUpper());
            return accessToken;
        }
        public string GetResponse(OAuthSession session, string url)
        {
            IToken accessToken = MyTokenBase;
            var response = session.Request(accessToken).Get().ForUrl(url).ToString();
            return response;
        }
        public XDocument GetWebResponseAsXml(HttpWebResponse response)
	    {
		    XmlReader xmlReader = XmlReader.Create(response.GetResponseStream());
		    XDocument xdoc = XDocument.Load(xmlReader);
		    xmlReader.Close();
		    return xdoc;
	    }
	    public string GetWebResponseAsString(HttpWebResponse response)
	    {
		    Encoding enc = System.Text.Encoding.GetEncoding(1252);
		    StreamReader loResponseStream = new
		    StreamReader(response.GetResponseStream(), enc);
		    return loResponseStream.ReadToEnd();
	    }
    }
