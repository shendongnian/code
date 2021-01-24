    Answer turns out to be:
    Use a new class AllLists
     public int ShoppingListID
        {
            get { return listID; }
            set { listID = value; }
        }
        public string ShopName
        {
            get { return shopName; }
            set { shopName = value; }
        }
    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
    {               
    var allList = (from s in conn.Table<ShoppingLists>() join p in 
                   conn.Table<Shops>() on s.ShopID equals 
                   p.ShopID select new **AllLists**
                   {
                       ShoppingListID = s.ShoppingListID,
                       ShopName = p.ShopName
                   });
    lvShoppingLists.ItemsSource = allList;
    }
    The selected item ID can then be 
    var selectedList = lvShoppingLists.SelectedItem as AllLists;
    GlobalVariables.SelectedShoppingListID = selectedList.ShoppingListID;
    Navigation.PushAsync(new ShoppingListPage());
