    public static string EncodeString(string s)
            {
                byte[] b = System.Text.Encoding.Default.GetBytes(s);
                return Convert.ToBase64String(b, 0, b.Length);
            }
