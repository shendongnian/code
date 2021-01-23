    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.ComponentModel;
    
    namespace StackOverflow
    {
        public partial class MainWindow : Window
        {
            ListCollectionView lcv;
            public MainWindow()
            {
                InitializeComponent();
    
                List<Item> items = new List<Item>();
                items.Add(new Item() { Name = "Item1", Category = "A" });
                
                items.Add(new Item() { Name = "Item5", Category = "B" });
                items.Add(new Item() { Name = "Item3", Category = "A" });
                items.Add(new Item() { Name = "Item4", Category = "B" });
                items.Add(new Item() { Name = "Item2", Category = "A" });
    
                lcv = new ListCollectionView(items);
                lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
    
                this.DataGrid.ItemsSource = lcv;
    
            }
    
            public class Item
            {
                public string Name { get; set; }
                public string Category { get; set; }
            }
    
            private void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
            {            
                e.Handled = true;
                lcv.SortDescriptions.Add(new SortDescription(e.Column.SortMemberPath, ListSortDirection.Ascending));
            }
        }
    }
