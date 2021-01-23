    public class Node : INotifyPropertyChanged
    {
        public object Value { get; private set; }
        public ObservableCollection<Node> Children { get; private set; }
        private bool isExpanded;
        public bool IsExpanded
        {
            get
            {
                return this.isExpanded;
            }
            set
            {
                if (this.isExpanded != value)
                {
                    this.isExpanded = value;
                    NotifyPropertyChanged("IsExpanded");
                }
            }
        }
        public Node(object value)
        {
            Value = value;
            Children = new ObservableCollection<Node>();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
     }
