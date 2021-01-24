    string myBotNewVersionURL = "https://raw.githubusercontent.com/MyBotRun/MyBot/master/LastVersion.txt";
    
                WebClient myBotNewVersionClient = new WebClient();
                Stream stream = myBotNewVersionClient.OpenRead(myBotNewVersionURL);
                StreamReader reader = new StreamReader(stream);
                String content = reader.ReadToEnd();
    
                var sb = new StringBuilder(content.Length);
                foreach (char i in content)
                {
                    if (i == '\n')
                    {
                        sb.Append(Environment.NewLine);
                    }
                    else if (i != '\r' && i != '\t')
                        sb.Append(i);
                }
    
                content = sb.ToString();
    
                var vals = content.Split(
                                            new[] { Environment.NewLine },
                                            StringSplitOptions.None
                                        )
                            .SkipWhile(line => !line.StartsWith("[general]"))
                            .Skip(1)
                            .Take(1)
                            .Select(line => new
                            {
                                Key = line.Substring(0, line.IndexOf('=')),
                                Value = line.Substring(line.IndexOf('=') + 1)
                            });
    
    
                Console.WriteLine("Key : " + vals.FirstOrDefault().Key + " Value : " + vals.FirstOrDefault().Value);
