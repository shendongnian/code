    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.Xml;
    namespace SoapTests
    {
        class Program
        {
            static void Main(string[] args)
            {
                // code presumes there is an sslcert associated with the url/port below
                var url = "https://127.0.0.1:443/";
                using (var server = new MyServer(url, MyClient.NamespaceUri))
                {
                    server.Start(); // requests will occur on other threads
                    using (var client = new MyClient())
                    {
                        client.Url = url;
                        Console.WriteLine(client.SendTextAsync("hello world").Result);
                    }
                }
            }
        }
        [WebServiceBinding(Namespace = NamespaceUri)]
        public class MyClient : SoapHttpClientProtocol
        {
            public const string NamespaceUri = "http://myclient.org/";
            public async Task<string> SendTextAsync(string text)
            {
                // TODO: add client certificates using this.ClientCertificates property
                var result = await InvokeAsync(nameof(SendText), new object[] { text }).ConfigureAwait(false);
                return result?[0]?.ToString();
            }
            // using this method is not recommended, as async is preferred
            // but we need it with this attribute to make underlying implementation happy
            [SoapDocumentMethod]
            public string SendText(string text) => SendTextAsync(text).Result;
            // this is the new Task-based async model (TAP) wrapping the old Async programming model (APM)
            public Task<object[]> InvokeAsync(string methodName, object[] input, object state = null)
            {
                if (methodName == null)
                    throw new ArgumentNullException(nameof(methodName));
                return Task<object[]>.Factory.FromAsync(
                    beginMethod: (i, c, o) => BeginInvoke(methodName, i, c, o),
                    endMethod: EndInvoke,
                    arg1: input,
                    state: state);
            }
        }
        // server implementation
        public class MyServer : TinySoapServer
        {
            public MyServer(string url, string namespaceUri)
                : base(url)
            {
                if (namespaceUri == null)
                    throw new ArgumentNullException(nameof(namespaceUri));
                NamespaceUri = namespaceUri;
            }
            // must be same as client namespace in attribute
            public override string NamespaceUri { get; }
            protected override bool HandleSoapMethod(XmlDocument outputDocument, XmlElement requestMethodElement, XmlElement responseMethodElement)
            {
                switch (requestMethodElement.LocalName)
                {
                    case "SendText":
                        // get the input
                        var text = requestMethodElement["text", NamespaceUri]?.InnerText;
                        text += " from server";
                        AddSoapResult(outputDocument, requestMethodElement, responseMethodElement, text);
                        return true;
                }
                return false;
            }
        }
        // simple generic SOAP server
        public abstract class TinySoapServer : IDisposable
        {
            private readonly HttpListener _listener;
            protected TinySoapServer(string url)
            {
                if (url == null)
                    throw new ArgumentNullException(nameof(url));
                _listener = new HttpListener();
                _listener.Prefixes.Add(url); // this requires some rights if not used on localhost
            }
            public abstract string NamespaceUri { get; }
            protected abstract bool HandleSoapMethod(XmlDocument outputDocument, XmlElement requestMethodElement, XmlElement responseMethodElement);
            public async void Start()
            {
                _listener.Start();
                do
                {
                    var ctx = await _listener.GetContextAsync().ConfigureAwait(false);
                    ProcessRequest(ctx);
                }
                while (true);
            }
            protected virtual void ProcessRequest(HttpListenerContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));
                // TODO: add a call to context.Request.GetClientCertificate() to validate client cert
                using (var stream = context.Response.OutputStream)
                {
                    ProcessSoapRequest(context, stream);
                }
            }
            protected virtual void AddSoapResult(XmlDocument outputDocument, XmlElement requestMethodElement, XmlElement responseMethodElement, string innerText)
            {
                if (outputDocument == null)
                    throw new ArgumentNullException(nameof(outputDocument));
                if (requestMethodElement == null)
                    throw new ArgumentNullException(nameof(requestMethodElement));
                if (responseMethodElement == null)
                    throw new ArgumentNullException(nameof(responseMethodElement));
                var result = outputDocument.CreateElement(requestMethodElement.LocalName + "Result", NamespaceUri);
                responseMethodElement.AppendChild(result);
                result.InnerText = innerText ?? string.Empty;
            }
            protected virtual void ProcessSoapRequest(HttpListenerContext context, Stream outputStream)
            {
                // parse input
                var input = new XmlDocument();
                input.Load(context.Request.InputStream);
                var ns = new XmlNamespaceManager(new NameTable());
                const string soapNsUri = "http://schemas.xmlsoap.org/soap/envelope/";
                ns.AddNamespace("soap", soapNsUri);
                ns.AddNamespace("x", NamespaceUri);
                // prepare output
                var output = new XmlDocument();
                output.LoadXml("<Envelope xmlns='" + soapNsUri + "'><Body/></Envelope>");
                var body = output.SelectSingleNode("//soap:Body", ns);
                // get the method name, select the first node in our custom namespace
                bool handled = false;
                if (input.SelectSingleNode("//x:*", ns) is XmlElement requestElement)
                {
                    var responseElement = output.CreateElement(requestElement.LocalName + "Response", NamespaceUri);
                    body.AppendChild(responseElement);
                    if (HandleSoapMethod(output, requestElement, responseElement))
                    {
                        context.Response.ContentType = "application/soap+xml; charset=utf-8";
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        var writer = new XmlTextWriter(outputStream, Encoding.UTF8);
                        output.WriteTo(writer);
                        writer.Flush();
                        handled = true;
                    }
                }
                if (!handled)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            public void Stop() => _listener.Stop();
            public virtual void Dispose() => _listener.Close();
        }
    }
