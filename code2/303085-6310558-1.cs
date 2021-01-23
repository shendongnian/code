    public class ViewModel : INotifyPropertyChanged
    {
       public ObservableCollection<MyType> SharedCollection = new ObservableCollection<MyType>();
       ...
       ...
       public void UpdateData()
       {
           SharedCollection.Clear();
           SharedCollection.Add( stuff coming from somewhere );
       }
    }
