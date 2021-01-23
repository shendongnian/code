        private const string MY_AWS_ACCESS_KEY_ID = "YOUR KEY";
        private const string MY_AWS_SECRET_KEY = "YOUR KEY";
        private const string DESTINATION = "ecs.amazonaws.com";
        private const string NAMESPACE = "http://webservices.amazon.com/AWSECommerceService/2009-03-31";
        public static IEnumerable<AmazonBookSearchResult> AmazonItemLookup(string category, string browseNode, string keyWords)
        {
            SignedRequestHelper helper = new SignedRequestHelper(MY_AWS_ACCESS_KEY_ID, MY_AWS_SECRET_KEY, DESTINATION);
            String requestUrl;
            IDictionary<string, string> r1 = new Dictionary<string, String>();
            r1["Service"] = "AWSECommerceService";
            r1["Version"] = "2009-03-31";
            r1["Operation"] = "ItemSearch";
            r1["ResponseGroup"] = "ItemAttributes";
            r1["SearchIndex"] = category;
            r1["Keywords"] = keyWords;
            requestUrl = helper.Sign(r1);
            XmlDocument xmlDoc = sendRequest(requestUrl);            
            XDocument doc = XDocument.Load(new XmlNodeReader(xmlDoc));
            XNamespace ns = "http://webservices.amazon.com/AWSECommerceService/2009-03-31";
            IEnumerable<AmazonBookSearchResult> result =
                from items in doc.Element(ns + "ItemSearchResponse").Elements(ns + "Items").Elements(ns + "Item")
                select new AmazonBookSearchResult
                {
                    ASIN = (string)items.Element(ns + "ASIN")
                };
            int count = doc.Element(ns + "ItemSearchResponse").Elements(ns + "Items").Elements(ns + "Item").Count();
            return result;
        } // end Lookup()
