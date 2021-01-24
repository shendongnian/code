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
Going to explain my Thought process behind this quick as I known how frustrating this was for me.
I gave up on directly trying to access a clicked member in the list-view so my intention was to rather get the index of that "clicked item" and then set hard-coded "Price" values for every index so E.G if(index == 1) Pricing += 10;
Instead I realized that if I set a clicked event on the listview, Rather then the specific Data-template its self I can get the index like that thus the var clickedItem = (item).e.ClickedItem; e being the sender event args and from there you can simply ask the library to find the "clickedItem" and (item) being my observable collection so from there you have the clickedItem and you can now reqeust specifics from that requested item based on the Parameters of your Collection/List/Array ect  
