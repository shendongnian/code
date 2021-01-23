    public class NonGenericBaseViewModel
    {
       ObservableCollection<object> ItemsAsObjects{get;set;}
    }
    public class ViewModelBase<T> : NonGenericBaseViewModel
    {
         public  ObservableCollection<T> Items { get; set; }
    }
