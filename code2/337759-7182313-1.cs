    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBox toBeGCdTextBox = new TextBox();
            stackPanel.Children.Add(toBeGCdTextBox);
            Binding textBinding = new Binding
            {
                Path = new PropertyPath("Text"),
                Source = toBeGCdTextBox
            };
            textBox.SetBinding(TextBox.TextProperty, textBinding);
            _weak = new WeakReference(toBeGCdTextBox);
        }
        private WeakReference _weak;
        private void isAliveButton_Click(object sender, RoutedEventArgs e)
        {
            GC.Collect();
            MessageBox.Show(_weak.IsAlive.ToString());
        }
        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.Assert(_weak.Target == stackPanel.Children[3]);
            stackPanel.Children.Remove(stackPanel.Children[3]);
        }
    }
