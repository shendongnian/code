    Regex pattern = new Regex("\\s+\\S+$");
    string[] items = new string[lbContent.Items.Count];
    lbContent.Items.CopyTo(items, 0);
    // Replace the last column with empty strings
    items = (from i in items
             let m = pattern.Match(i).Value
             select i.Replace(m, string.Empty)).ToArray();
    lbContent.Items.Clear();
    lbContent.Items.AddRange(items);
