    public class View1Model
    {
         private ObservableCollection<SomeModel> _DataModelCollection;
         public ObservableCollection<SomeModel> DataModelCollection
         {
            get { return this._DataModelCollection; }
            set { this._DataModelCollection = value; }
         }
     }
