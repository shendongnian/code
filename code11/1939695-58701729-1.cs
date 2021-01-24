    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        Item _selectedItem = (Item)lbItems.SelectedItem;
        
        Item existingItem = _context.Item.Local.SingleOrDefault(x => x.ItemId == _selectedItem.ItemId);
        if (existingItem != null)
            _context.Item.Remove(existingItem);
        else
        {
            _context.Item.Attach(_selectedItem);
            _context.Item.Remove(_selectedItem);
        }
        _context.SaveChanges();
    }
