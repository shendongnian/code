    Regex pattern = new Regex("\\s+\\S+$");
    string[] items = new string[lbContent.Items.Count];
    lbContent.Items.CopyTo(items, 0);
    items = (from i in items
             let t = i.Trim(),
             m = pattern.Match(t).Value
             orderby m
             select t.Replace(m, string.Empty)).ToArray();
    lbContent.Items.Clear();
    lbContent.Items.AddRange(items);
