    var languages = new List<string>();
    foreach (ListItem item in cblLanguages.Items)
    {
        if (item.Selected)
        {
            languages.Add(item.Value);
        }
    }
