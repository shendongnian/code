    public class TestClass : INotifyPropertyChanged
    {
        private Dictionary<string, object> BackingStore = new Dictionary<string,object>();
        private Dictionary<string, bool> Changes = new Dictionary<string, bool>();
        private string _testString;
        public string TestString
        {
            get { return _testString; }
            set { _testString = value; OnPropertyChanged("TestString", value); }
        }
        private bool HasChanges { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public TestClass(string value)
        {
            _testString = value;
            SaveValues();
        }
        public void SaveValues()
        {
            // Expensive, to use reflection, especially if LOTS of objects are going to be used. 
            // You can use straight properties here if you want, this is just the lazy mans way.
            this.GetType().GetProperties().ToList().ForEach(tProp => { BackingStore[tProp.Name] = tProp.GetValue(this, null); Changes[tProp.Name] = false; });
            HasChanges = false;
            
        }
        public void RevertValues()
        {
            // Again, you can use straight properties here if you want. Since this is using Property setters, will take care of Changes dictionary.
            this.GetType().GetProperties().ToList().ForEach(tProp => tProp.SetValue(this, BackingStore[tProp.Name], null));
            HasChanges = false;
        }
        private void OnPropertyChanged(string propName, object propValue)
        {
            // If you have any object types, make sure Equals is properly defined to check for correct uniqueness.
            Changes[propName] = BackingStore[propName].Equals(propValue);
            HasChanges = Changes.Values.Any(tr => tr);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
