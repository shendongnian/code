    using System;
    using System.IO;
    using System.Windows;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private Action<string> _AddToListBox;
    
            public MainWindow()
            {
                InitializeComponent();
                _AddToListBox = AddToListBox;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Action action = Go;
                action.BeginInvoke(null, null);
            }
    
            private void Go()
            {
                foreach (var file in Directory.EnumerateFiles(@"c:\windows\system32\"))
                {
                    Dispatcher.BeginInvoke(_AddToListBox, file);
                }
            }
    
            private void AddToListBox(string toAdd)
            {
                _FileList.Items.Add(toAdd);
            }
        }
    }
