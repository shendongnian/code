    public sealed class TabItem: ViewModelBase
    {
        public string HeaderImg { get; set; }
        public string HeaderSrt { get; set; }
        public string Guid { get; set; }
        //public bool IsEnable { get; set; }
        public ViewModelBase Content { get; set; }
        private Visibility _MessageVisibilty;
        public Visibility MessageVisibilty
        {
            get { return _MessageVisibilty; }
            set {
                _MessageVisibilty = value;
                RaisePropertyChanged("MessageVisibilty");}
        }
    }
