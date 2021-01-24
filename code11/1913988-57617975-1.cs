    public partial class UCComboButton : UserControl
    {
        public UCComboButton()
        {
            InitializeComponent();
        }
        // We use this dependency property to bind a list to the combo box.
        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(IEnumerable), typeof(UCComboButton), new PropertyMetadata(null));
        public IEnumerable Source
        {
            get { return (IEnumerable)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }
        // This is to send the occurred event, in this case button click, to the parent, along with the selected data.
        public class SelectedItemEventArgs : EventArgs
        {
            public string SelectedChoice { get; set; }
        }
        public event EventHandler<SelectedItemEventArgs> ItemHasBeenSelected;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = ItemsComboBox.SelectedValue;
            ItemHasBeenSelected?.Invoke(this, new SelectedItemEventArgs { SelectedChoice = selected.ToString() });
        }
    }
