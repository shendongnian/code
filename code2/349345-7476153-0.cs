    /// <summary>
    /// Mocks an entire HttpContext for use in unit tests
    /// </summary>
    public class MockHttpContextBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockHttpContextBase"/> class.
        /// </summary>
        public MockHttpContextBase() : this(new Mock<Controller>().Object, "~/")
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MockHttpContextBase"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        public MockHttpContextBase(Controller controller) : this(controller, "~/")
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MockHttpContextBase"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public MockHttpContextBase(string url) : this(new Mock<Controller>().Object, url)
        {              
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MockHttpContextBase"/> class.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="url">The URL.</param>
        public MockHttpContextBase(ControllerBase controller, string url)
        {
            HttpContext = new Mock<HttpContextBase>();
            Request = new Mock<HttpRequestBase>();
            Response = new Mock<HttpResponseBase>();
            Output = new StringBuilder();
            HttpContext.Setup(x => x.Request).Returns(Request.Object);
            HttpContext.Setup(x => x.Response).Returns(Response.Object);
            HttpContext.Setup(x => x.Session).Returns(new FakeSessionState());
            Request.Setup(x => x.Cookies).Returns(new HttpCookieCollection());
            Request.Setup(x => x.QueryString).Returns(new NameValueCollection());
            Request.Setup(x => x.Form).Returns(new NameValueCollection());
            Request.Setup(x => x.ApplicationPath).Returns("~/");
            Request.Setup(x => x.AppRelativeCurrentExecutionFilePath).Returns(url);
            Request.Setup(x => x.PathInfo).Returns(string.Empty);
            Response.Setup(x => x.Cookies).Returns(new HttpCookieCollection());
            Response.Setup(x => x.ApplyAppPathModifier(It.IsAny<string>())).Returns((string path) => path);
            Response.Setup(x => x.Write(It.IsAny<string>())).Callback<string>(s => Output.Append(s));
            var requestContext = new RequestContext(HttpContext.Object, new RouteData());
            controller.ControllerContext = new ControllerContext(requestContext, controller);
        }
        /// <summary>
        /// Gets the HTTP context.
        /// </summary>
        /// <value>The HTTP context.</value>
        public Mock<HttpContextBase> HttpContext { get; private set; }
        /// <summary>
        /// Gets the request.
        /// </summary>
        /// <value>The request.</value>
        public Mock<HttpRequestBase> Request { get; private set; }
        /// <summary>
        /// Gets the response.
        /// </summary>
        /// <value>The response.</value>
        public Mock<HttpResponseBase> Response { get; private set; }
        /// <summary>
        /// Gets the output.
        /// </summary>
        /// <value>The output.</value>
        public StringBuilder Output { get; private set; }
    }
    /// <summary>
    /// Provides Fake Session for use in unit tests
    /// </summary>
    public class FakeSessionState : HttpSessionStateBase
    {
        /// <summary>
        /// backing field for the items in session
        /// </summary>
        private readonly Dictionary<string, object> _items = new Dictionary<string, object>();
        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified name.
        /// </summary>
        /// <param name="name">the key</param>
        /// <returns>the value in session</returns>
        public override object this[string name]
        {
            get
            {
                return _items.ContainsKey(name) ? _items[name] : null;
            }
            set
            {
                _items[name] = value;
            }
        }
    }
