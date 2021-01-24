            private static Regex _regex = 
            new Regex(@"(\\u(?<Value>[a-zA-Z0-9]{4}))+", RegexOptions.Compiled);
        private static string ConvertUnicodeEscapeSequencetoUTF8Characters(string sourceContent)
        {
            //Check https://stackoverflow.com/questions/9738282/replace-unicode-escape-sequences-in-a-string
            return _regex.Replace(
                sourceContent, m =>
                {
                    var urlEncoded = m.Groups[0].Value.Replace(@"\u00", "%");
                    var urlDecoded = System.Web.HttpUtility.UrlDecode(urlEncoded);
                    return urlDecoded;
                }
            );
        }
