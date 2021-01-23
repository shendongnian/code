    var lines = msg.Split(new []{Environment.NewLine}, StringSplitOptions.None);
    var headerLines = lines.TakeWhile(s => s != string.Empty);
    var bodyLines = lines.SkipWhile(s => s != string.Empty).Skip(1);
    string body = bodyLines.Aggregate((s1, s2) => s1 + Environment.NewLine + s2);
    var headers = (from hl in headerLines
                   select new { Key = hl.Split(new []{':'}, 2)[0].Trim()
                              , Value = hl.Split(new[] {':'}, 2)[1].Trim()}).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
