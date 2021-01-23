    class MyViewModel : INotifyPropertyChanged
    {
      public MyViewModel()
      {
        Companies = new ItemListViewModel<string>();
        Departments = new ItemListViewModel<string>();
        ...
     }
      public ItemListViewModel<string> Companies { get; set; }
      public ItemListViewModel<string> Departments { get; set; }
    }
 
