    public class SettingRow : ObservableObject
    {
        public int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                ID = value;
                RaisePropertyChangedEvent("ID");
            }
        }
        public object _Value;
        public object Value
        {
            get { return _Value; }
            set
            {
                Value = value;
                RaisePropertyChangedEvent("Value");
            }
        }
        public string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                Name = value;
                RaisePropertyChangedEvent("Name");
            }
        }
        public string _Unit;
        public string Unit
        {
            get { return _Unit; }
            set
            {
                Unit = value;
                RaisePropertyChangedEvent("Unit");
            }
        }
    }
