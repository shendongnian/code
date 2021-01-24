public void ListCountH_ListChanged(object sender, ListChangedEventArgs e) {
    //use e.ListChangedType property to determine if a row was added
    if (e.ListChangedType == ListChangedType.ItemAdded) {
    ...Do Your Work Here...
    }
}
Then add the handler to your BindingList<int>'s ListChanged event:
    boundList.ListChanged += new ListChangedEventHandler(ListCountH_ListChanged);
Edit: Depending what you are using the list for, the current top answer may be better, as ObservableCollection is far more lightweight if all you need to know is when an item is added. However, BindingList has some advantages with items that support INotifyPropertyChanged (it can propagate the items' PropertyChanged events to its ListChanged event), or if you need support for Sorting, Searching, or ReadOnly lists. 
