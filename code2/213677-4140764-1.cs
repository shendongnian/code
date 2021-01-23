    using System.Windows;
    namespace WpfApplication1
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          MessageBox.Show("Button clicked!");
        }
      }
    }
