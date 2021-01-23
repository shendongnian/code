        private string GetFileData(string fileName,string matchChar)
        {
            String x=string.Empty;
            int blockCount = 2048;
            int offset = 0;
            string pattern= matchChar;
            int k = -1;
            using (var sr = new System.IO.FileStream(fileName, System.IO.FileMode.Open))
            {
                while ((sr.CanRead) && (k!= 0))
                {
                    byte[] bt = new byte[blockCount];
                     k = sr.Read(bt, 0, blockCount);
                    string so = System.Text.UTF8Encoding.UTF8.GetString(bt);
                    var m = new System.Text.RegularExpressions.Regex(pattern).Matches(so);
                    foreach (System.Text.RegularExpressions.Match item in m)
                    {
                        x += item.Value;
                    }
                }
            }
            return x;
        }
