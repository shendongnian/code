    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            Item fixedItem;
            int selectedIndex;
            public Window1()
            {
                InitializeComponent();
                listBox1.ItemContainerGenerator.ItemsChanged += new System.Windows.Controls.Primitives.ItemsChangedEventHandler(list_changes);
            }
    
    
    
            private void list_changes(object sender, System.Windows.Controls.Primitives.ItemsChangedEventArgs e)
            {
    
            }
    
            private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                listBox1.Items.Add(new Item { ItemName = "item0" });
                listBox1.Items.Add(new Item { ItemName = "item1" });
                listBox1.Items.Add(new Item { ItemName = "item2" });
                listBox1.Items.Add(new Item { ItemName = "item3" });
                listBox1.Items.Add(new Item { ItemName = "item4" });
                listBox1.Items.Add(new Item { ItemName = "item5" });
                listBox1.Items.Add(new Item { ItemName = "item6" });
            }
    
            private void button2_Click(object sender, RoutedEventArgs e)
            {
    
                if (listBox1.SelectedItem != null)
                {
                    fixedItem = (Item)listBox1.SelectedItem;
                    selectedIndex = listBox1.SelectedIndex;
                }
                listBox1.Items.Insert(0, new Item { ItemName = "item7" });
                listBox1.Items.Insert(0, new Item { ItemName = "item8" });
                listBox1.Items.Insert(0, new Item { ItemName = "item9" });
                listBox1.Items.Insert(0, new Item { ItemName = "item10" });
                listBox1.Items.Insert(0, new Item { ItemName = "item11" });
                listBox1.Items.Insert(0, new Item { ItemName = "item12" });
                listBox1.Items.Insert(0, new Item { ItemName = "item13" });
                listBox1.Items.Insert(0, new Item { ItemName = "item14" });
                listBox1.Items.Insert(0, new Item { ItemName = "item15" });
    
                listBox1.Items.Remove(fixedItem);
                listBox1.Items.Insert(selectedIndex, fixedItem);
                listBox1.SelectedItem = fixedItem;
                listBox1.ScrollIntoView(fixedItem);
            }
    
            private void button3_Click(object sender, RoutedEventArgs e)
            {
                if (listBox1.SelectedItem != null)
                {
                    fixedItem = (Item)listBox1.SelectedItem;
                    selectedIndex = listBox1.SelectedIndex;
                }
    
                listBox1.Items.Insert(0, new Item { ItemName = "item16" });
                listBox1.Items.Insert(0, new Item { ItemName = "item17" });
                listBox1.Items.Insert(0, new Item { ItemName = "item18" });
                listBox1.Items.Insert(0, new Item { ItemName = "item19" });
                listBox1.Items.Insert(0, new Item { ItemName = "item20" });
                listBox1.Items.Insert(0, new Item { ItemName = "item21" });
                listBox1.Items.Insert(0, new Item { ItemName = "item22" });
                listBox1.Items.Insert(0, new Item { ItemName = "item23" });
                listBox1.Items.Insert(0, new Item { ItemName = "item24" });
    
                listBox1.Items.Remove(fixedItem);
                listBox1.Items.Insert(selectedIndex, fixedItem);
                listBox1.SelectedItem = fixedItem;
                listBox1.ScrollIntoView(fixedItem);
            }
        }
    
        class Item
        {
            public string ItemName { get; set; }
        }
    }
