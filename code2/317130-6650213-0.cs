    private ItemObservableCollection<MyChild> children;
    
    public MyParent()
    {
        this.children = new ItemObservableCollection<MyChild>();
        this.children.ItemPropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
        {
            if (string.Equals("IsChanged", e.PropertyName, StringComparison.Ordinal))
            {
                this.RaisePropertyChanged("IsChanged");
            }
        };
    }
