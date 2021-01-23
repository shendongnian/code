    private void IncrementalSearch(char ch)
    {
      if (DateTime.Now - lastKeyPressTime > new TimeSpan(0, 0, 1))
        searchString = ch.ToString();
      else
        searchString += ch;
      lastKeyPressTime = DateTime.Now;
      var item = lbxFieldNames
        .Items
        .Cast<string>()
        .Where(it => it.StartsWith(searchString, true, CultureInfo.InvariantCulture))
        .FirstOrDefault();
      if (item == null)
        return;
      var index = lbxFieldNames.Items.IndexOf(item);
      if (index < 0)
        return;
      lbxFieldNames.SelectedIndex = index;
    }
