        public string Encrypt(IDictionary<string, string> dictionary)
        {
            var str = string.Join("///", dictionary.Select(x => $"{x.Key} :: {x.Value}"));
            var bytes = new UTF8Encoding().GetBytes(str);
            return Convert.ToBase64String(bytes);
        }
        public IDictionary<string, string> Decrypt(string value)
        {
            var bytes = Convert.FromBase64String(value);
            var items = new UTF8Encoding().GetString(bytes).Split(new string[] { "///" }, StringSplitOptions.None);
            var dictionary = new Dictionary<string, string>();
            foreach (var str in items)
            {
                var temp = str.Split(new string[] { " :: " }, StringSplitOptions.None);
                dictionary.Add(temp[0], temp[1]);
            }
            return dictionary;
        }
