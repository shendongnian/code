        public IUriHelper uriHelper { get; private set; }
        public Backend(HttpClient httpInstance, IUriHelper uriHelper)
        {
            http = httpInstance;
            this.uriHelper = uriHelper;
