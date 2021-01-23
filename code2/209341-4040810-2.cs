    public ObservableCollection<CheckedItem> List { get;set;}
    
    public class CheckedItem : INotifyPropertyChanged
    {
      private bool selected;
      private string description;
      public bool Selected 
      { 
         get { return selected; }
         set 
         {
            selected = value;
            OnPropertyChanged("Selected");
         }
      }
      public string Description 
      { 
         get { return description; }
         set
         {
             description = value;
             OnPropertyChanged("Description");
         }
       }
      /* INotifyPropertyChanged implementation */
    }
