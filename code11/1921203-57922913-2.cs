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
                for (int i = 0; i < Children.Count; i++)
                {
                    Children[i].Number = string.Format("{0}.{1}", number, i + 1);
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
            for (int i = 0; i < TreeItems.Count; i++)
            {
                TreeItems[i].Number = (i + 1).ToString();
            }
        }
    }
