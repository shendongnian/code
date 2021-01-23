    using System;
    using System.Collections.Generic;
    using System.Windows;
    using Microsoft.Win32;
    
    namespace WpfApplication10 {
        public class ViewModel {
            public IEnumerable<String> Items {
                get { return RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Vendor\Product\Systems").GetSubKeyNames(); }
            }
        }
    
        /// <summary>
        ///   Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window {
            public MainWindow() {
                InitializeComponent();
                DataContext = new ViewModel();
            }
        }
    }
