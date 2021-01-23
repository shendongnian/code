    public class MyVM : BindableObject //where BindableObject is a base object that supports INotifyPropertyChanged and provides a RaisePropertyChanged method
    {
        private readonly ObservableCollection<MyEnum> _myEnums;
        private MyEnum _selectedEnum;
    
        public MyVM()
        {
           //create and populate collection
           _myEnums = new ObservableCollection<MyEnum>();
           foreach (MyEnum myEnum in Enum.GetValues(typeof(MyEnum)))
           {
             _myEnums.Add(myEnum);
           }
         }
    
         //list property to bind to
         public IEnumerable<MyEnum> MyEnumValues
         {
             get { return _myEnums; }
         }
    
         //a property to bind the selected item to
         public MyEnum SelectedEnum
         {
             get { return __selectedEnum; }
             set
             {
                if (!Equals(__selectedEnum, value))
                {
                  __selectedEnum = value;
                  RaisePropertyChanged("SelectedEnum");
                }
             }
         }
    }
