      public static string MD5(this string normal)
            {
                byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(normal);
                try
                {
                    System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
                    cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    byte[] hash = cryptHandler.ComputeHash(textBytes);
                    string ret = "";
                    foreach (byte a in hash)
                    {
                        if (a < 16)
                            ret += "0" + a.ToString("x");
                        else
                            ret += a.ToString("x");
                    }
                    return ret;
                }
                catch
                {
                    throw;
                }
            }
