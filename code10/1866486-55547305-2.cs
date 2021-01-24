c#
 private void mylist_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = (Item)e.ClickedItem;
            Pricing += clickedItem.Price;
            var collection = (ObservableCollection<Item>)mylist.ItemsSource;
            int index = collection.IndexOf(clickedItem);
          
            addtototal();
        }
        public int addtototal()
        {
            Model.TotalSpent = Pricing;
            txtTotal.Text = Pricing.ToString();
            return Pricing;
         
        }
I gave up on directly trying to access a clicked member in the list-view so my intention was to rather get the index of that "clicked item" and then set hard-coded "Price" values for every index so E.G if(index == 1) Pricing += 10;
Instead I utilized the event args to pull a value from the indexed "item".
I apologize if the explanation is horrid. 
