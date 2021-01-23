    static string GetParam(string input, string param) {
                var pattern = new Regex(@"[\\*](?<value>.+)" + param);
                var split = input.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                var line = split.SingleOrDefault(l => pattern.IsMatch(l));
                if(line != null) {
                    return pattern.Match(line).Groups["value"].Value.Trim();
                }
                return null;
            }
