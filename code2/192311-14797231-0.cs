            var browserCapabilities = new HttpBrowserCapabilities
            {
                Capabilities = new Hashtable { { string.Empty, userAgent } }
            };
            var capabilitiesFactory = new BrowserCapabilitiesFactory();
            capabilitiesFactory.ConfigureBrowserCapabilities(new NameValueCollection(), browserCapabilities);
            return browserCapabilities;
