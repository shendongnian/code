    void DeleteClicked(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        int itemNumber = (int)button.Tag;
        ShopItem item = shopItems.FirstOrDefault(item => item.labelNumber = itemNumber);
        if (item != null)
            shopItems.Remove(item);
    }
