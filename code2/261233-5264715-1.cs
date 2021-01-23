    public static string ConvertToUri(string uri_string)
            {
                StringBuilder Encoded = new StringBuilder();
                foreach (char Ch in uri_string)
                {
                    if (Uri.EscapeUriString(Ch.ToString()) != Ch.ToString())
                    {
                        Encoded.Append("%");
                        Encoded.AppendFormat("{0:x2}", Encoding.Unicode.GetBytes(Ch.ToString())[0]);
                    }
                    else
                    {
                        Encoded.Append(Ch);
                    }
                }
                return Encoded.ToString();
            }
