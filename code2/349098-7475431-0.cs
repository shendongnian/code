    string CONSUMER_KEY = "www.bherila.net";
    string CONSUMER_SECRET = "RpKF7ykWt8C6At74TR4_wyIb";
    string APPLICATION_NAME = "bwh-wssearch-01";
    string SCOPE = "https://docs.google.com/feeds/";
    public ActionResult Auth()
    {
        string callbackURL = String.Format("{0}{1}", Request.Url.ToString(), "List");
        OAuthParameters parameters = new OAuthParameters()
        {
            ConsumerKey = CONSUMER_KEY,
            ConsumerSecret = CONSUMER_SECRET,
            Scope = SCOPE,
            Callback = callbackURL,
            SignatureMethod = "HMAC-SHA1"
        };
        OAuthUtil.GetUnauthorizedRequestToken(parameters);
        string authorizationUrl = OAuthUtil.CreateUserAuthorizationUrl(parameters);
        Session["parameters"] = parameters;
        ViewBag.AuthUrl = authorizationUrl;
        return View();
    }
    public ActionResult List()
    {
        if (Session["parameters"] != null)
        {
            OAuthParameters parameters = Session["parameters"] as OAuthParameters;
            OAuthUtil.UpdateOAuthParametersFromCallback(Request.Url.Query, parameters);
            try
            {
                OAuthUtil.GetAccessToken(parameters);
                GOAuthRequestFactory authFactory = new GOAuthRequestFactory("writely", APPLICATION_NAME, parameters);
                var service = new DocumentsService(authFactory.ApplicationName);
                service.RequestFactory = authFactory;
                var query = new DocumentsListQuery();
                //query.Title = "recipe";
                var feed = service.Query(query);
                var docs = new List<string>();
                foreach (DocumentEntry entry in feed.Entries)
                {
                    docs.Add(entry.Title.Text);
                }
                //var result = feed.Entries.ToList().ConvertAll(a => a.Title.Text);
                return View(docs);
            }
            catch (GDataRequestException gdre)
            {
                HttpWebResponse response = (HttpWebResponse)gdre.Response;
                //bad auth token, clear session and refresh the page
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    Session.Clear();
                    Response.Write(gdre.Message);
                }
                else
                {
                    Response.Write("Error processing request: " + gdre.ToString());
                }
                throw;
            }
        }
        else
        {
            return RedirectToAction("Index");
        }
    }
