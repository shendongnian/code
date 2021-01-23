    using System.Windows;
    
    namespace WpfTutorialStatusBarGrid
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
    
            private void TxtEditor_SelectionChanged(object sender, RoutedEventArgs e)
            {
                var row = txtEditor.GetLineIndexFromCharacterIndex(txtEditor.CaretIndex);
                var col = txtEditor.CaretIndex - txtEditor.GetCharacterIndexFromLineIndex(row);
    
                lblCursorPosition.Text = $"Line {row + 1}, Char {col + 1}";
            }
        }
    }
