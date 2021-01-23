    private string Encode(string text)
            {
                text = HTMLEncodeSpecialChars(text);
                return HttpUtility.UrlEncode(text);
            }
    
            public string HTMLEncodeSpecialChars(string text)
            {
                StringBuilder sb = new System.Text.StringBuilder();
                foreach (char c in text)
                {
                    if (c > 127) // special chars
                        sb.Append(String.Format("&#{0};", (int)c));
                    else
                        sb.Append(c);
                }
                return sb.ToString();
            }
