    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    
    namespace SortDemo
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                Items = new ObservableCollection<Item>();
                Items.Add(new Item() { ID = "AAA", Value = 2 });
                Items.Add(new Item() { ID = "BBB", Value = 1 });
    
                DataContext = this;
            }
    
            public ObservableCollection<Item> Items { get; private set; }
    
            private void OnSort(object sender, RoutedEventArgs e)
            {
                string sortProperty = (sender as FrameworkElement).Tag as string;
                _itemsControl.Items.SortDescriptions.Clear();
                _itemsControl.Items.SortDescriptions.Add(new SortDescription(sortProperty, ListSortDirection.Ascending)); 
            }
        }
    
        public class Item
        {
            public string ID { get; set;}
            public int Value { get; set; }
    
            public override string ToString()
            {
                return ID + " " + Value;
            }
        }
    }
