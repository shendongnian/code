    lst1.ItemContainerGenerator.ItemsChanged += 
        (o, e) => this.ListViewGeneratorItemsChanged(o, e, lst1);
    lst2.ItemContainerGenerator.ItemsChanged += 
        (o, e) => this.ListViewGeneratorItemsChanged(o, e, lst2);
    lst3.ItemContainerGenerator.ItemsChanged += 
        (o, e) => this.ListViewGeneratorItemsChanged(o, e, lst3);
    void ListViewGeneratorItemsChanged(object sender, ItemsChangedEventArgs e, ListView listView)
    {
        // We have the ListView and also the ItemContainerGenerator (in sender)
    }
