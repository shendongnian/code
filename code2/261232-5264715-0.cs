    public static string ConvertToUri(string uri_string)
                {
                    StringBuilder Encoded = new StringBuilder();
                    foreach (char Ch in uri_string)
                    {
                        int unicode_code = Encoding.Unicode.GetBytes(Ch.ToString())[0];
                        /* If it's greater than 127 it means it is not a ASCII character
                           So it is converted to unicode beginning with a '%'
                         */
                        if (unicode_code > 127)
                        {
                            Encoded.Append("%");
                            Encoded.AppendFormat("{0:x2}", unicode_code);
                        }
                        else
                        {
                            Encoded.Append(Ch);
                        }
                    }
                    return Encoded.ToString();
                }
