    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void TextBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = sender as UIElement;
            if (element != null)
            {
                Boolean success = element.Focus(); //Always returns false and doesn't take focus.
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.IsVisible)
                NameTextBox.Visibility = Visibility.Collapsed;
            else
                NameTextBox.Visibility = Visibility.Visible;
        }
    }
