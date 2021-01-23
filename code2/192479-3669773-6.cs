    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace ObjectBrowser
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
    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          var o = new XmlDataProvider();
          o.Source = new Uri("http://www.stackoverflow.com");
          propertyTree1.ObjectGraph = o;
        }
      }
    }
