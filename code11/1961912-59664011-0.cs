    private static Dictionary<string, string> Dictionary(string str)
            {
                var dictionary = new Dictionary<string, string>();
                var splitOnSpace = str.Split(" ");
                var value = string.Empty;
                var key = "";
                var i = 0;
                while (i < splitOnSpace.Length)
                {
                    var item = splitOnSpace[i];
                    if (item.Contains(":"))
                    {
                        var split = item.Split(':');
                        key = split[0];
                        value = split[1];
                        dictionary.Add(key, value);
                    }
                    else
                    {
                        value += " " + item;
                        dictionary[key] = value;
                    }
                    i++;
                }
                return dictionary;
            }
