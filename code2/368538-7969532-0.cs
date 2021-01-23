    public class MyViewModel : INotifyPropertyChanged
    {
          ObservableCollection<Resident> Residents { get; }
          
          private Resident _selectedItem;
          public Resident SelectedItem
          {
               get { return _selectedItem; }
               set
               {
                    _selectedItem = value;
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if(handler != null)
                        handler(this, new PropertyChangedEventArgs("SelectedItem");
               }
          }
    }
