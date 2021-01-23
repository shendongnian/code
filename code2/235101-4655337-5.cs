    public static IHttpModule ThatModule = new WebServiceAuthenticationModule();
    // http://www.west-wind.com/weblog/posts/44979.aspx
    public override void Init()
    {
    	base.Init();
    	ThatModule.Init(this);
    }
