    private void btnDelete_Click(object sender, RoutedEventArgs e)
    {
        int itemId = lbItems.SelectedItem.ItemId; // Where a simple view model was put in the SelectedItem, not an entity.
        
        Item existingItem = _context.Item.Local.SingleOrDefault(x => x.ItemId == itemId);
        if (existingItem != null)
            _context.Item.Remove(existingItem);
        else
        { 
            var tempItem = new Item { ItemId = itemId }; 
            _context.Item.Attach(tempItem);
            _context.Item.Remove(tempItem);
        }
        _context.SaveChanges();
    }
