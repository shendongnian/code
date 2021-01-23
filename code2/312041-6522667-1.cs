    /// <summary>
        /// Attribute for Mobile Redirection when the request action comes from a mobile device.
        /// </summary>
        public class MobileRedirectAttribute : AuthorizeAttribute
        {
            private const string defaultMobileController = "Mobile";
    
            #region Properties
    
            /// <summary>
            /// Gets or sets the action.
            /// </summary>
            /// <value>The action.</value>
            private string Action { get; set; }
    
            /// <summary>
            /// Gets or sets the controller.
            /// </summary>
            /// <value>The controller.</value>
            private string Controller { get; set; }
    
            private UrlHelper _urlHelper;
            /// <summary>
            /// Sets the URL helper.
            /// </summary>
            /// <value>The URL helper.</value>
            internal UrlHelper UrlHelper { set { this._urlHelper = value; } }
    
            /// <summary>
            /// Gets or sets the last URL redirected.
            /// </summary>
            /// <value>The last URL redirected.</value>
            internal string RedirectedTo { get; private set; }
    
            /// <summary>
            /// Gets or sets a value indicating whether this instance is mobile device.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance is mobile device; otherwise, <c>false</c>.
            /// </value>
            internal bool IsMobileDevice { get; private set; }
    
            #endregion
    
            #region Methods
    
            /// <summary>
            /// Determines whether the specified controller is mobile.
            /// </summary>
            /// <param name="controller">The controller.</param>
            /// <returns>
            /// 	<c>true</c> if the specified controller is mobile; otherwise, <c>false</c>.
            /// </returns>
            private bool IsMobile(Controller controller)
            {
                bool isMobile = controller.Request.Browser.IsMobileDevice;
                string userAgent = controller.Request.UserAgent.ToLower();
    
                return (isMobile || userAgent.Contains("iphone") || userAgent.Contains("ipod") || userAgent.Contains("blackberry") || userAgent.Contains("mobile")
                                 || userAgent.Contains("opera mini") || userAgent.Contains("palm"));
            }
    
            /// <summary>
            /// Called when [authorization].
            /// </summary>
            /// <param name="filterContext">The filter context.</param>
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                Controller controller = filterContext.Controller as Controller;
                this.IsMobileDevice = IsMobile(controller); //test porpouse
                if (this.IsMobileDevice)
                {
                    this.RedirectedTo = GetUrlRedirectAction(filterContext.RequestContext);
                    filterContext.Result = new RedirectResult(this.RedirectedTo);
                }
            }
    
            /// <summary>
            /// Gets the URL redirect action.
            /// </summary>
            /// <param name="requestContext">The request context.</param>
            /// <returns></returns>
            private string GetUrlRedirectAction(RequestContext requestContext)
            {
                UrlHelper urlHelper = _urlHelper;
                if (urlHelper == null) //mocking porpouse;
                    urlHelper = new UrlHelper(requestContext);
    
                return urlHelper.Action(this.Action, this.Controller, requestContext.RouteData.Values);
            }
    
            #endregion
    
            #region Constructor
    
            /// <summary>
            /// Initializes a new instance of the <see cref="MobileRedirectAttribute"/> class.
            /// </summary>
            /// <param name="action">The action.</param>
            public MobileRedirectAttribute(string action)
            {
                this.Action = action;
            }
    
            /// <summary>
            /// Initializes a new instance of the <see cref="MobileRedirectAttribute"/> class.
            /// </summary>
            /// <param name="controller">The controller.</param>
            /// <param name="action">The action.</param>
            public MobileRedirectAttribute(string controller, string action)
            {
                this.Action = action;
                this.Controller = controller;
            }
    
            #endregion
    
        }
