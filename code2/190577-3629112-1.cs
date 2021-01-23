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
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    
    namespace ContextTest
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            ObservableCollection<MyClass> items;
            ListCollectionView lcv;
    
            public MainWindow()
            {
                InitializeComponent();
    
                items = new ObservableCollection<MyClass>();
                lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(items);
                this.lb.ItemsSource = lcv;
                items.Add(new MyClass() { Name = "A" });
                items.Add(new MyClass() { Name = "B" });
                items.Add(new MyClass() { Name = "C" });
                items.Add(new MyClass() { Name = "D" });
                items.Add(new MyClass() { Name = "E" });
    
            }
    
            public class MyClass
            {
                public string Name { get; set; }
            }
    
            int ctr = 0;
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                MyClass selectedItem = this.lb.SelectedItem as MyClass;
                int index = this.items.IndexOf(selectedItem);
                this.items[index] = new MyClass() { Name = "NewItem" + ctr++.ToString() };
                lcv.MoveCurrentToPosition(index);
            }
    
        }
    }
