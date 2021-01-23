    public class RequestResponseLoggerModule : IHttpModule
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();
    
        #region CaptureStream
    
        private class CaptureStream : Stream
        {
            private readonly Stream _streamToCapture;
            private readonly Encoding _encoding;
    
            public string StreamContent { get; private set; }
    
            public CaptureStream(Stream streamToCapture, Encoding encoding)
            {
                _encoding = encoding;
                _streamToCapture = streamToCapture;
            }
    
            public override bool CanRead { get { return _streamToCapture.CanRead; } }
            public override bool CanSeek { get { return _streamToCapture.CanSeek; } }
            public override bool CanWrite { get { return _streamToCapture.CanWrite; } }
            public override long Length { get { return _streamToCapture.Length; } }
            public override long Position
            {
                get { return _streamToCapture.Position; }
                set { _streamToCapture.Position = value; }
            }
    
    
            public override void Flush()
            {
                _streamToCapture.Flush();
            }           
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                return _streamToCapture.Read(buffer, offset, count);
            }
    
            public override long Seek(long offset, SeekOrigin origin)
            {
                return _streamToCapture.Seek(offset, origin);
            }
    
            public override void SetLength(long value)
            {
                _streamToCapture.SetLength(value);
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                StreamContent += _encoding.GetString(buffer);
                _streamToCapture.Write(buffer, offset, count);
            }
    
            public override void Close()
            {
                _streamToCapture.Close();
                base.Close();
            }
        }
    
        #endregion
    
        #region IHttpModule Members
    
        private HttpApplication _context;
        public void Dispose()
        {
    
        }
    
        private static string Extensions_Key = "RequestResponseLoggerModule.Extensions";
        private static string Files_Key = "RequestResponseLoggerModule.Files";
        private static string Request_Key = "RequestResponseLoggerModule.Request";
        private static string Response_Key = "RequestResponseLoggerModule.Response";
    
        private IEnumerable<string> _Extenstions = new string[] { };
        private IEnumerable<string> _Files = new string[] { };
        private bool _LogAlwaysRequest = false;
        private bool _LogAlwaysResponse = false;
        private bool _IsMatch = false;
    
        public void Init(HttpApplication context)
        {
            _Extenstions = ConfigurationManager.AppSettings[Extensions_Key].ToLower().Split(',').
                Select(x => x.Trim()).ToArray();
            _Files = ConfigurationManager.AppSettings[Files_Key].ToLower().Split(',').
                Select(x => x.Trim()).ToArray();
            _LogAlwaysRequest = ConfigurationManager.AppSettings[Request_Key] == "ALWAYS";
            _LogAlwaysResponse = ConfigurationManager.AppSettings[Response_Key] == "ALWAYS";
            
            _context = context;
    
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.PreSendRequestContent += new EventHandler(context_PreSendRequestContent);
        }
    
        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            _context.Response.Filter = new CaptureStream(_context.Response.Filter, _context.Response.ContentEncoding);
        }
    
        void context_BeginRequest(object sender, EventArgs e)
        {
            if (_Extenstions.Count() > 0)
            {
                string ext = VirtualPathUtility.GetExtension(_context.Request.FilePath).
                    Substring(1).ToLower();
                if (_Extenstions.Contains(ext))
                {
                    _IsMatch = true;
                }
            }
            if (_Files.Count() > 0)
            {
                string fileName = VirtualPathUtility.GetFileName(_context.Request.FilePath).ToLower();
                if (_Files.Contains(fileName))
                {
                    _IsMatch = true;
                }
            }
    
            if (_LogAlwaysRequest || _IsMatch)
            {
                StreamReader reader = new StreamReader(_context.Request.InputStream);
                string requestText = reader.ReadToEnd();
                _context.Request.InputStream.Position = 0;
                //LOG requestText
            }
        }
    
        void context_PreSendRequestContent(object sender, EventArgs e)
        {
            if (_LogAlwaysResponse || _IsMatch)
            {
                CaptureStream filter = _context.Response.Filter as CaptureStream;
                if (filter != null)
                {
                    string responseText = filter.StreamContent;
                    //LOG responseText
                }
            }
        }
    
        #endregion
    }
