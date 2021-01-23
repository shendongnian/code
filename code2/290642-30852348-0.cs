            var text = "example-123-example";
            var pattern = @"-(\d+)-";
            var replaced = Regex.Replace(text, pattern, (_match) =>
            {
                Group group = _match.Groups[1];
                string replace = "AA";
                return String.Format("{0}{1}{2}", _match.Value.Substring(0, group.Index - _match.Index), replace, _match.Value.Substring(group.Index - _match.Index + group.Length));
            });
