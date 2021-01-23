    lbBooks.Items.Where(n => _books.Contains(int.Parse(n.Value)))
                 .Select(n => SetSelected(n));
    private ListItem SetSelected(Item item)
    {
        ListItem result = item as ListItem;
        result.Selected = true;
        return result;
    }
