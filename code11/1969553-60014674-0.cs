    using System;
    using System.Threading.Tasks;
    using System.Windows;
    namespace WpfApp1
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
      
        async Task LongRunningProcess()
        {
            await Task.Delay(1000);
            
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                DateTime dt = DateTime.Now;
                textBox1.Text = dt.ToString("hh:mm:ss");
                await Task.Run(() => LongRunningProcess());
                
            }
        }
    }
