     internal static IEnumerable<int> GetCheckedRows(IEnumerable<string> paramKeys)
        {
            return paramKeys
                .Where(f => f.Contains("$"))
                .Where(f => System.Text.RegularExpressions.Regex.IsMatch(f, "ckUpdate[0-9]+$"))
                .Select(p => int.Parse(System.Text.RegularExpressions.Regex.Match(p, "[0-9]+$").Value));
        }
