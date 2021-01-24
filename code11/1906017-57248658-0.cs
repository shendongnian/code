        public static Uri BuildUri(string baseUrl, string path, Dictionary<string, string> queryParams = null)
        {
            var uriBuilder = new UriBuilder(baseUrl) {Path = path};
            if (queryParams != null)
            {
                var query = string.Join("&", queryParams.Select(x => $"{x.Key}={x.Value}").ToArray());
                uriBuilder.Query = query;
            }
            return uriBuilder.Uri;
        }
