    public class ViewModel : INotifyPropertyChanged
    {
        private double _columnWidth;
        public double ColumnWidth 
        {
            get { return _columnWidth; }
            set { _columnWidth = value; FirePropertyChanged(); }
        }
        private List<GridItem> _gridItems = new List<GridItem>()
            {
                new GridItem() { ColumnOne = "1.1", ColumnTwo = "1.2", ColumnThree = "1.3" },
                new GridItem() { ColumnOne = "2.1", ColumnTwo = "2.2", ColumnThree = "2.3" },
                new GridItem() { ColumnOne = "3.1", ColumnTwo = "3.2", ColumnThree = "3.3" }
            };
        public List<GridItem> GridItems 
        { 
            get { return _gridItems; }
        }
        private void FirePropertyChanged([CallerMemberName] string caller = "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(caller));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
    public class GridItem
    {
        public string ColumnOne { get; set; }
        public string ColumnTwo { get; set; }
        public string ColumnThree { get; set; }
    }
