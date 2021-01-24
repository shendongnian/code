    string values = "((\"ITEM\" \"05\") (\"NUMBER\" \"1\") (\"DESCRIPTION\" \" * RECHTE INSTEEKKOP. 1 / 4\" - 8MM\") (\"ARTICLENUMBER\" \"S110010000104\"))";
    
    var items = values.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Split(new[] { ' ' }, 2));
    
    Dictionary<string, string> dict = new Dictionary<string, string>();
    foreach (var item in items)
    {
        if (!string.IsNullOrEmpty(item[0])) dict.Add(item[0], item[1]);
    }
