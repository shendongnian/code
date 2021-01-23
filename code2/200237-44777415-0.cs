            private string GetDeviceName(string ip)
        {
            WebClient myWebClient = new WebClient(1000);
            try
            {
                System.IO.Stream s = myWebClient.OpenRead("http://" + ip);
                var sr = new System.IO.StreamReader(s);
                while (!sr.EndOfStream)
                {
                    var L = sr.ReadLine();
                    var sb = new StringBuilder();
                    var st = 0;
                    var end = 0;
                    if ((st = L.ToLower().IndexOf("<title>")) != -1)
                    {
                        sb.Append(L);
                        while ((end = L.ToLower().IndexOf("</title>")) == -1)
                        {
                            L = sr.ReadLine();
                            sb.Append(L);
                        }
                        sr.Close();
                        s.Close();
                        myWebClient.Dispose();
                        var title = sb.ToString().Substring(st + 7, end - st - 7);
                        Regex r = new Regex("&#[^;]+;");
                        title = r.Replace(title, delegate (Match match)
                        {
                            string value = match.Value.ToString().Replace("&#", "").Replace(";", "");
                            int asciiCode;
                            if (int.TryParse(value, out asciiCode))
                                return Convert.ToChar(asciiCode).ToString();
                            else
                                return value;
                        });
                        return $"Router/AP ({title})";
                    }
                }
                sr.Close();
                s.Close();
                myWebClient.Dispose();
            }
            catch (System.Net.WebException ex)
            {
                var response = ex.Response as HttpWebResponse;
                if (response == null)
                    return "";
                var name = response.Headers?["WWW-Authenticate"]?.Substring(12).Trim('"');
                myWebClient.Dispose();
                return name;
            }
            return "";
        }
