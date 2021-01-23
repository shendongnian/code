        public static string[] Parse(string pattern, string groupName, string input)
        {
            var list = new List<string>();
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            for (var match = regex.Match(input); match.Success; match = match.NextMatch())
            {
                list.Add(string.IsNullOrWhiteSpace(groupName) ? match.Value : match.Groups[groupName].Value);
            }
            return list.ToArray();
        }
        public static string[] ParseUri(string input)
        {
            const string pattern = @"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*";
            return Parse(pattern, string.Empty, input);
        }
