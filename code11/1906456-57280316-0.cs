    using System.Windows;
    using System.ComponentModel;
    namespace GridHelperTest
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window, INotifyPropertyChanged
      {
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        public MainWindow ( )
        {
          InitializeComponent ();
          DataContext = this ;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void TestButton_Click (object sender, RoutedEventArgs e)
        {
          MessageBox.Show ( "HELLO!", "Greetings", MessageBoxButton.OK, MessageBoxImage.Information );
        }
        private void CreateGrid_Click (object sender, RoutedEventArgs e)
        {
          if (int.TryParse ( rowSizeText.Text, out int rowResult ))
          {
            RowCount = rowResult;
            OnPropertyChanged("RowCount");
          }
          if (int.TryParse ( columnSizeText.Text, out int columnResult ))
          {
            ColumnCount = rowResult;
            OnPropertyChanged("ColumnCount");
          }
        }
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
      }
    }
