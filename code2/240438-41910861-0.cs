     WebClient client = new WebClient();
                using (Stream data = client.OpenRead(Text))
                {
                    using (StreamReader reader = new StreamReader(data))
                    {
                        string content = reader.ReadToEnd();
                        string pattern = @"((https?|ftp|gopher|telnet|file|notes|ms-help):((//)|(\\\\))+[\w\d:#@%/;$()~_?\+-=\\\.&]*)";
                        MatchCollection matches = Regex.Matches(content,pattern);
                        List<string> urls = new List<string>();
                        foreach (Match match in matches)
                        {
                                urls.Add(match.Value);
                        }
    
                  }
