            string test = "<p>John &amp; Sarah went to see &ldquo;Scream 4&rdquo;.</p>";
            string decode = HttpUtility.HtmlDecode(test);
            string encode = HttpUtility.HtmlEncode(decode);
            StringBuilder builder = new StringBuilder();
            foreach (char c in encode)
            {
                if ((int)c > 127)
                {
                    builder.Append("&#");
                    builder.Append((int)c);
                    builder.Append(";");
                }
                else
                {
                    builder.Append(c);
                }
            }
            string result = builder.ToString();
