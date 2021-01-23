    class WebProxyEx : WebProxy, IList
        {
            private object[] _contents = new object[8];
            private int _count;
    
            public WebProxy w;
    
            public WebProxyEx(string address)
            {
                _count = 0;
                w = new WebProxy(address);
                this.Add(w.Address.Authority);
            }
    ...
