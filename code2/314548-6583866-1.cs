    public abstract  class NonGenericBaseViewModel
    {
       ObservableCollection<object> ItemsAsObjects{get;set;}
    }
    public abstract  class ViewModelBase<T> : NonGenericBaseViewModel
    {
         public  ObservableCollection<T> Items { get; set; }
    }
