    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cmbUsers.Items.Add(new ComboBoxItem { Content = "Test" });
            cmbUsers.SelectedIndex = 0;
        }
        private void cmbUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbUsers.SelectedItem != null)
            {
                MessageBox.Show(cmbUsers.SelectedItem.ToString());
            }
        }
    }
