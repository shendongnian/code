    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace SDKSample
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
    
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
    
            public MainViewModel ViewModel
            {
                get { return this.DataContext as MainViewModel; }
            }
    
            void SwitchViewMenu(object sender, RoutedEventArgs args)
            {
                MenuItem mi = (MenuItem)sender;
                ViewModel.ViewName = mi.Header.ToString();
            }
    
            private void Window_SourceInitialized(object sender, EventArgs e)
            {
                ViewModel.ViewName = "gridView";
            }
        }
    }
