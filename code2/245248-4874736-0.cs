    public partial class SubsetSelectionLists<T> : UserControl
    {
        public List<T> SetCollection { get; set; }
    
        public List<T> SubsetCollection { get; set; }
    
        public SubsetSelectionLists()
        {
            SubsetSelectiongrid.DataContext = this;
        }
    
        private void selectionBtnClick(object sender, RoutedEventArgs e)
        {
            SubsetCollection.AddRange(SetCollection);
        }
    
        private void removeBtnClick(object sender, RoutedEventArgs e)
        {
            SubsetCollection.RemoveAll(x => SetCollection.Contains(x));
        }
    }
