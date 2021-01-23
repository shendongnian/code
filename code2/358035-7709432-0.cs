    var items = new List<string>();
    foreach (Match match in Regex.Matches(text, "<m>(.*?)</m>"))
        items.Add(match.Groups[1].Value);
    string output = String.Join(" ", items);
    someTextBox.Text =  output;
    if (items.Any())
       anotherTextBox.Text = items[0];
    
    if (items.Count > 2)
       whateverTextBox.Text = items[3];
