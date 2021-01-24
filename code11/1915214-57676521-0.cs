    public sealed class TabItem : ViewModelBase
    {
        private string _headerImg;
        private string _headerSrt { get; set; }
        private string _guid { get; set; }
        private Visibility _isEnable { get; set; }
        private ViewModelBase _content { get; set; }
    
        public string HeaderImg
        {
            get { return _headerImg; }
            set
            {
                _headerImg = value;
                RaisePropertyChanged("HeaderImg");
            }
        }
    
        // Set the properties for the other fields as above
    }
