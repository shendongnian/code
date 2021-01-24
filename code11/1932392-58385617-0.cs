    using System.Windows;
    using Microsoft.Win32;
    
    namespace WpfApp1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                var dialog = new OpenFileDialog
                {
                    Filter = "All Files | *.*"
                };
    
                while (true)
                {
                    var b = dialog.ShowDialog();
                    if (b == null || !b.Value)
                        break;
    
                    MessageBox.Show(dialog.FileName);
                }
            }
        }
    }
