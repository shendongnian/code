    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApp
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                TextBox1.Focus(); // So the caret shows up
                string word = "hello";
                TextBox1.Text = File.ReadAllText("file.txt");
                var i = TextBox1.Text.IndexOf(word);
                if (i != -1) TextBox1.CaretIndex = i;
            }
        }
    }
