    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void ValidateInitialFieldsOnChange(object sender,
                TextChangedEventArgs e)
            {
                textBox3.IsEnabled = !string.IsNullOrEmpty(textBox1.Text)
                    && !string.IsNullOrEmpty(textBox2.Text)
                    ;
            }
        }
    }
