            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("foo", "bar");
            var dict = new Dictionary<string, string>();
            foreach (string key in nvc.Keys)
            {
                dict.Add(key, nvc[key]);
            }
            string json = new JavaScriptSerializer().Serialize(dict);
            Console.WriteLine(json);
