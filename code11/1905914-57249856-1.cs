    public class ViewModel: INotifyPropertyChanged
    {
      public ViewModel()
      {
        this.TabDatas = new ObservableCollection<TabData>()
        {
          new TabData("First Tab"),
          new TabData("Second Tab"),
          new TabData("Third Tab")
        };
      }
      // Adding a new TabData item to the TabDatas collection 
      // will dynamically create a new TabItem inside the TabControl
      public void AddNewTab()
      {
        this.TabDatas.Add(new TabData("Fourth Tab"));
      }
    
     
      public ObservableCollection<TabData> TabDatas { get; set; }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
