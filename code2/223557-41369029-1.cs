        public static Uri CreateUri(string url)
        {
            var uri = new Uri(url);
            if (url.Contains("%28") || url.Contains("%29"))
            {
                var originalParser = ReflectionHelper.GetValueByReflection(uri, "m_Syntax") as UriParser;
                var parser = new MyUriParser(originalParser);
                ReflectionHelper.SetValueByReflection(parser, "m_Scheme", "http");
                ReflectionHelper.SetValueByReflection(parser, "m_Port", 80);
                ReflectionHelper.SetValueByReflection(uri, "m_Syntax", parser);
            }
            return uri;
        }
