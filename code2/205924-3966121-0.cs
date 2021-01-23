    public class TabItemModel : INotifyPropertyChanged
    {
        public string TabTitle { get; set; }
        private bool canSave;
        public bool CanSave
        {
            get { return canSave; }
            set
            {
                canSave = value;
                OnPropertyChanged("CanSave");
            }
        }
    //...
    }
