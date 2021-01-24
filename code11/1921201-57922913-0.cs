    public class TreeItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<TreeItem> Children { get; }
            = new ObservableCollection<TreeItem>();
        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                if (number != value)
                {
                    number = value;
                    PropertyChanged?.Invoke(
                        this, new PropertyChangedEventArgs(nameof(Number)));
                }
                int n = 0;
                foreach (var childItem in Children)
                {
                    childItem.Number = string.Format("{0}.{1}", number, ++n);
                }
            }
        }
    }
    public class ViewModel
    {
        public ObservableCollection<TreeItem> TreeItems { get; }
            = new ObservableCollection<TreeItem>();
        public void UpdateTreeItemNumbers()
        {
            int n = 0;
            foreach (var item in TreeItems)
            {
                item.Number = (++n).ToString();
            }
        }
    }
