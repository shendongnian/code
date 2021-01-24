      public class ViewDesignMock : INotifyPropertyChanged
    {
        public ViewDesignMock() { }
        public System.String userInstruction
        {
            get => "TESTING22222222222222";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        //private string _userInstruction = "TESTING22666222";
        //public string userInstruction
        //{
        //    get
        //    {
        //        return _userInstruction;
        //    }
        //    set
        //    {
        //        _userInstruction = value;
        //        OnPropertyRaised("userInstruction");
        //    }
        //}
    }
