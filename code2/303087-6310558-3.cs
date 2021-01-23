    public class ViewModel : INotifyPropertyChanged
    {
       public ObservableCollection<MyType> SharedCollection = new ObservableCollection<MyType>();
       ...
       ...
       public void UpdateData()
       {
           SharedCollection.Clear();
           var data = GetMyDataFromSQLQuery();
           foreach( var item in data )
           {
               SharedCollection.Add( item );
           }
       }
    }
