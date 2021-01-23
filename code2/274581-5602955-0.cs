    List<string> list = new List<string>();
    foreach(ListItem li in DropDownListID.Items)
    {
        string value = li.Value.ToString();
        string text = li.Text;
        list.Add(string.Concat(value, ", ", text));
    }
