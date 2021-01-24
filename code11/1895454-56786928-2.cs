        public partial class DialogVM : ViewModelBase
        {
            private string _Name;
            public string Name
            {
              get { return _Name; }
              set { Set(ref _Name, value); }
            }
            private string _Roll;
            public string Roll
            {
              get { return _Roll; }
              set { Set(ref _Roll, value); }
            }
        }
  
