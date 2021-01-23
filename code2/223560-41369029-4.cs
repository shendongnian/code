    public sealed class MyUriParser : System.UriParser
    {
        private UriParser _originalParser;
        private MethodInfo _getComponentsMethod;
        public MyUriParser(UriParser originalParser) : base()
        {
            if (_originalParser == null)
            {
                _originalParser = originalParser;
                _getComponentsMethod = typeof(UriParser).GetMethod("GetComponents", BindingFlags.NonPublic | BindingFlags.Instance);
                if (_getComponentsMethod == null)
                {
                    throw new MissingMethodException("UriParser", "GetComponents");
                }
            }
        }
        private static Regex rx = new Regex(@"^(?<Scheme>[^:]+):(?://((?<User>[^@/]+)@)?(?<Host>[^@:/?#]+)(:(?<Port>\d+))?)?(?<Path>([^?#]*)?)?(\?(?<Query>[^#]*))?(#(?<Fragment>.*))?$",RegexOptions.Compiled | RegexOptions.ExplicitCapture | RegexOptions.Singleline);
        private Match m = null;
        protected override string GetComponents(Uri uri, UriComponents components, UriFormat format)
        {
            var original = (string)_getComponentsMethod.Invoke(_originalParser, BindingFlags.InvokeMethod, null, new object[] { uri, components, format }, null);
            if (components == UriComponents.PathAndQuery)
            {
                var reg = rx.Match(uri.OriginalString);
                var path = reg.Groups["Path"]?.Value;
                var query = reg.Groups["Query"]?.Value;
                if (path != null && query != null) return $"{path}?{query}";
                if (query == null) return $"{path}";
                return $"{path}";
            }
            return original;
        }
      
    }
