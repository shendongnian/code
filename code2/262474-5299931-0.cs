    public SelectionChangedEventArgs:EventArgs
    {
        public int SelectedIndex {get; private set;}
        public SelectionChangedEventArgs (int selIdx)
        {
            this.SelectedIndex = selId;
        }
    }
    
    public partial class MyWPFControl : UserControl
    {
        public event EventHandler<EventArgs> SelectionChange;
    
        public MyWPFControl()
        {
            InitializeComponent();
        }
    
        private void statComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnSelectionChange(statComboBox.SelectedIndex);
        }
    
        private void OnSelectionChange(int selIdx)
        {
            if (SelectionChange != null)
                SelectionChange(this, new SelectionChangedEventArgs(selIdx));
        }
    }
