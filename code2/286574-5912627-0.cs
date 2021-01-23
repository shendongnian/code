    Item aItem = new Item();
    aItem.Clicked += new EventHandler(ItemClicked);
    
    void ItemClicked(object sender, EventArgs e)
    {
        MessageBox.Show("Clicked!");
    }
