    public SelectionChangedEventArgs:EventArgs
    {
        public int SelectedIndex {get; private set;}
        public SelectionChangedEventArgs (int selIdx)
        {
            this.SelectedIndex = selIdx;
        }
    }
    
    public partial class MyWPFControl : UserControl
    {
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;
    
        public MyWPFControl()
        {
            InitializeComponent();
        }
    
        private void statComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnSelectionChanged(statComboBox.SelectedIndex);
        }
    
        private void OnSelectionChanged(int selIdx)
        {
            if (SelectionChange != null)
                SelectionChanged(this, new SelectionChangedEventArgs(selIdx));
        }
    }
