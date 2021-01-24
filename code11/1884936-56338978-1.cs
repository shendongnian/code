    public void DeleteCheckedItems()
    {
        var checkedItems = Items.Where(item => item.IsChecked).ToList();
        checkedItems.ForEach(item => Items.Remove(item));
    }
