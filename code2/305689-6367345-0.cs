    public class CustomTestControllerBuilder : TestControllerBuilder
    {
        public CustomTestControllerBuilder()
        {
            var httpContext = new Moq.Mock<HttpContextBase>();
            var request = new Moq.Mock<HttpRequestBase>();
            var response = new Moq.Mock<HttpResponseBase>();
            var server = new Moq.Mock<HttpServerUtilityBase>();
            var _cache = HttpRuntime.Cache;
            httpContext.Setup(x=> x.Request).Returns(request.Object);
            httpContext.Setup(x => x.Response).Returns(response.Object);
            httpContext.Setup(x => x.Session).Returns(Session);
            httpContext.Setup(x => x.Server).Returns(server.Object);
            httpContext.Setup(x => x.Cache).Returns(_cache);
            var items = new Dictionary<object, object>();
            httpContext.Setup(x => x.Items).Returns(items);
            QueryString = new NameValueCollection();
            request.Setup(x => x.QueryString).Returns(QueryString);
            Form = new NameValueCollection();
            request.Setup(x => x.Form).Returns(Form);
            request.Setup(x => x.AcceptTypes).Returns((Func<string[]>)(() => AcceptTypes));
            var files = new WriteableHttpFileCollection();
            Files = files;
            request.Setup(x => x.Files).Returns(files);
            Func<NameValueCollection> paramsFunc = () => new NameValueCollection { QueryString, Form };
            request.Setup(x => x.Params).Returns(paramsFunc);
            request.Setup(x => x.AppRelativeCurrentExecutionFilePath).Returns(
                    (Func<string>)(() => AppRelativeCurrentExecutionFilePath));
            request.Setup(x => x.ApplicationPath).Returns((Func<string>)(() => ApplicationPath));
            request.Setup(x => x.PathInfo).Returns((Func<string>)(() => PathInfo));
            request.Setup(x => x.RawUrl).Returns((Func<string>)(() => RawUrl));
            response.SetupProperty(x => x.Status);
            httpContext.SetupProperty(x=>x.User);
            var ms = new MemoryStream(65536);
            var sw = new StreamWriter(ms);
            response.SetupGet(x=>x.Output).Returns(sw);
            response.SetupGet(x => x.OutputStream).Returns(ms);
            response.Setup(x => x.Write(It.IsAny<string>())).Callback((string s) => { sw.Write(s); });
            response.Setup(x => x.Write(It.IsAny<char>())).Callback((char s) => { sw.Write(s); });
            response.Setup(x => x.Write(It.IsAny<object>())).Callback((object s) => { sw.Write(s); });
            //_mocks.Replay(HttpContext);
            //_mocks.Replay(request);
            //_mocks.Replay(response);
            TempDataDictionary = new TempDataDictionary();
            HttpContext = httpContext.Object;
        }
    }
    }
