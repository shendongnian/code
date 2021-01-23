        private string GetUrlParameter(HttpRequestBase request, string parName)
        {
            string result = string.Empty;
            var urlParameters = HttpUtility.ParseQueryString(request.Url.Query);
            if (urlParameters.AllKeys.Contains(parName))
            {
                result = urlParameters.Get(parName);
            }
            return result;
        }
