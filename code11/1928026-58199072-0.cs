    public class ResourceRequestHandlerExt : ResourceRequestHandler
    {
        private string userAgent;
        public ResourceRequestHandlerExt(string userAgent)
        {
            this.userAgent = userAgent;
        }
        protected override CefReturnValue OnBeforeResourceLoad(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            var headers = request.Headers;
            headers["User-Agent"] = userAgent;
            request.Headers = headers;
            return base.OnBeforeResourceLoad(chromiumWebBrowser, browser, frame, request, callback);
        }
    }
Define the class which implements RequestHandler. The base class has a required GetResourceRequestHandler function which allows use to pass our user agent to the ResourceRequestHandlerExt class.
    public class RequestHandlerExt : RequestHandler
    {
        private string userAgent;
        public RequestHandlerExt(string userAgent)
        {
            this.userAgent = userAgent;
        }
        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            if (!string.IsNullOrEmpty(userAgent)) return new ResourceRequestHandlerExt(userAgent);
            else return base.GetResourceRequestHandler(chromiumWebBrowser, browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
        }
    }
When instantiating the ChromiumWebBrowser object, you set the RequestHandler to the RequestHandlerExt class above using:
ChromiumWebBrowser browser = new ChromiumWebBrowser();
browser.RequestHandler = new RequestHandlerExt(userAgent);
- Specifying a user agent in CefSettings will get overwritten, so its not needed in this case.
- If you do not specify a user agent, then no headers will be added/modified
- The user agent can be changed for each browser.Load(url) call.
