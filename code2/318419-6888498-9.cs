        public const string MAXFILESIZEERR = "maxFileSizeErr";
        
        public int MaxRequestLengthInMB
        {
            get
            {
                string key = "MaxRequestLengthInMB";
                double maxRequestLengthInKB = 4096; /// This is IIS' default setting 
                if (Application.AllKeys.Any(k => k == key) == false)
                {
                    var section = ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
                    if (section != null)
                        maxRequestLengthInKB = section.MaxRequestLength;
                    Application.Lock();
                    Application.Add(key, maxRequestLengthInKB);
                    Application.UnLock();
                }
                else
                    maxRequestLengthInKB = (double)Application[key];
                return Convert.ToInt32(Math.Round(maxRequestLengthInKB / 1024));
            }
        }
        void Application_BeginRequest(object sender, EventArgs e)
        {
            HandleMaxRequestExceeded(((HttpApplication)sender).Context);
        }
        void HandleMaxRequestExceeded(HttpContext context)
        {
            /// Skip non ASPX requests.
            if (context.Request.Path.ToLowerInvariant().IndexOf(".aspx") < 0 && !context.Request.Path.EndsWith("/"))
                return;
            /// Convert folder requests to default doc; 
            /// otherwise, IIS7 chokes on the Server.Transfer.
            if (context.Request.Path.EndsWith("/"))
                context.RewritePath(Request.Path + "default.aspx");
            /// Deduct 100 Kb for page content; MaxRequestLengthInMB includes 
            /// page POST bytes, not just the file upload.
            int maxRequestLength = MaxRequestLengthInMB * 1024 * 1024 - (100 * 1024);
            if (context.Request.ContentLength > maxRequestLength)
            {
                /// Need to read all bytes from request, otherwise browser will think
                /// tcp error occurred and display "uh oh" screen.
                ReadRequestBody(context);
                
                /// Set flag so page can tailor response.
                context.Items.Add(MAXFILESIZEERR, true);
                /// Transfer to original page.
                /// If we don't Transfer (do nothing or Response.Redirect), request
                /// will still throw "Maximum request limit exceeded" exception.
                Server.Transfer(Request.Path);
            }
        }
        void ReadRequestBody(HttpContext context)
        {
            var provider = (IServiceProvider)context;
            var workerRequest = (HttpWorkerRequest)provider.GetService(typeof(HttpWorkerRequest));
            // Check if body contains data
            if (workerRequest.HasEntityBody())
            {
                // get the total body length
                int requestLength = workerRequest.GetTotalEntityBodyLength();
                // Get the initial bytes loaded
                int initialBytes = 0;
                if (workerRequest.GetPreloadedEntityBody() != null)
                    initialBytes = workerRequest.GetPreloadedEntityBody().Length;
                if (!workerRequest.IsEntireEntityBodyIsPreloaded())
                {
                    byte[] buffer = new byte[512000];
                    // Set the received bytes to initial bytes before start reading
                    int receivedBytes = initialBytes;
                    while (requestLength - receivedBytes >= initialBytes)
                    {
                        // Read another set of bytes
                        initialBytes = workerRequest.ReadEntityBody(buffer,
                            buffer.Length);
                        // Update the received bytes
                        receivedBytes += initialBytes;
                    }
                    initialBytes = workerRequest.ReadEntityBody(buffer,
                        requestLength - receivedBytes);
                }
            }
        }
