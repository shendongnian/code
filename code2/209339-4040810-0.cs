    public ObservableCollection<CheckedItem> List { get;set;}
    
    public class CheckedItem
    {
      public bool Selected { get; set; }
      public string Description { get; set; }
    }
