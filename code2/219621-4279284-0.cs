    class FooObservableCollection : ObservableCollection<Foo>
    {
        protected override void InsertItem(int index, Foo item)
        {
            base.Add(index, Foo);
    
            if (this.CollectionChanged != null)
                this.CollectionChanged(this, new NotifyCollectionChangedEventArgs (NotifyCollectionChangedAction.Add, item, index);
        }
    }
    
    var collection = new FooObservableCollection();
    collection.CollectionChanged += CollectionChanged;
    
    collection.Add(new Foo());
    
    void CollectionChanged (object sender, NotifyCollectionChangedEventArgs e)
    {
        Foo newItem = e.NewItems.OfType<Foo>().First();
    }
