            string test = "&amp; and &lt;. Entities like &ldquo; and &mdash;";
            string result = HttpUtility.HtmlDecode(test);
            StringBuilder newString = new StringBuilder();
            foreach (char c in result)
            {
                if (!Char.IsLetterOrDigit(c) && !Char.IsWhiteSpace(c))
                {
                    newString.Append("&");
                    newString.Append((int)c);
                    newString.Append(";");
                }
                else
                {
                    newString.Append(c);
                }
            }
            string a = newString.ToString();
