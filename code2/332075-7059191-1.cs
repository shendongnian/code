    public void ProcessRequest(HttpContext context)
    {
        //Get parameter
        string Url = context.Request.QueryString["url"];
        string Username = context.Request.QueryString["username"];
        string Password = context.Request.QueryString["password"];
        //Set cache 
        HttpResponse Response = HttpContext.Current.Response;
        Response.Expires = 0;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "multipart/x-mixed-replace";
        // create processor
        Processor p = new Processor(context);    
        // create MJPEG video source
        MJPEGStream stream = new MJPEGStream(string.Format("{0}/video.cgi?user={1}&pwd={2}", Url, Username, Password));
        stream.NewFrame += new NewFrameEventHandler(p.stream_NewFrame);
        stream.Start();
    }
    
