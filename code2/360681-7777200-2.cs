        public static string StripHTML(this string htmlText)
        {
            var reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            return HttpUtility.HtmlDecode(reg.Replace(htmlText, string.Empty));
        }
