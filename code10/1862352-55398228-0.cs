    public class ListItemModel : INotifyPropertyChanged
    {
        public ListItemModel()
        {
            Entries = new ObservableCollection<Entry>();
            DataColumns = new ObservableCollection<DataGridColumn>();
        }
        private ObservableCollection<Entry> _entries;
        public ObservableCollection<Entry> Entries
        {
            get { return _entries; }
            set { _entries = value; NotifyPropertyChanged(); }
        }
        public ObservableCollection<DataGridColumn> DataColumns { get; set; }
        public bool IsSelected { get; set; }
        public void GenerateGrid()
        {
            if (Entries.Count != 0)
            {
                var columns = Entries[0]?.Cells;
                for (int i = 0; i < columns.Count; i++)
                {
                    Binding b = new Binding(string.Format("Cells[{0}].Value", i));
                    DataGridTextColumn text = new DataGridTextColumn();
                    text.Header = columns[i].Cond1.ToString();
                    text.Binding = b;
                    DataColumns.Add(text);
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
