            var result = entities.SelectMany(e => files.Select(f =>
            {
                var match = regex.Match(f);
                if (match.Success)
                {
                    if (match.Groups.Count > 1)
                    {
                        if (match.Groups[1].Value == e) return f;
                    }
                }
                return "";
            })).Where(s => !String.IsNullOrEmpty(s));
