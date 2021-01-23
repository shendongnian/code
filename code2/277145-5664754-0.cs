     protected static string GetString(string filename, int contentLength)
        {
            string retString;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                int length = (fs.Length < contentLength ? (int)fs.Length : contentLength);
                byte[] b = new byte[length];
                fs.Read(b, 0, contentLength);
                string str = System.Text.ASCIIEncoding.UTF8.GetString(b);
                if (str.LastIndexOf("\r") > 0)
                    retString = str.Substring(0, str.LastIndexOf("\r"));
                else
                    retString = str;
            }
            return retString;
        }
