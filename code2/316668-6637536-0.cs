    lbBooks.Items.Cast<ListItem>()
                    .Where(n => _books.Contains(int.Parse(n.Value)))
                    .Select(n => SetSelected(n));
    private ListItem SetSelected(ListItem listItem)
    {
        listItem.Selected = true;
        return listItem
    }
