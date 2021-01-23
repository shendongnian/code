    using System.Windows;
    using System.Windows.Input;
    namespace KeyInput
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            }
            private void OnButtonKeyDown(object sender, KeyEventArgs e)
            {
                test.Content = test.Content + e.Key.ToString();
            }
        }
    }
