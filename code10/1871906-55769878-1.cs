    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.ComponentModel;
    namespace WpfApplication2
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
           
            ViewModel vm = new ViewModel();
            DataContext = vm;
            vm.ModelList = new BindingList<Model>();
            Model md = new Model();
            md.ComboItems = new List<string>();
            md.ComboItems.Add("string1");
            md.ComboItems.Add("string2");
            md.ComboItems.Add("string3");
            vm.ModelList.Add(md);
            md = new Model();
            md.ComboItems = new List<string>();
            md.ComboItems.Add("string4");
            md.ComboItems.Add("string5");
            md.ComboItems.Add("string6");
            vm.ModelList.Add(md);
        }
      }
    }
