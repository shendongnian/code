    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            string fixedItem;
            public Window1()
            {
                InitializeComponent();
                listBox1.ItemContainerGenerator.ItemsChanged += new System.Windows.Controls.Primitives.ItemsChangedEventHandler(list_changes);
            }
    
    
    
            private void list_changes(object sender, System.Windows.Controls.Primitives.ItemsChangedEventArgs e)
            {
                listBox1.ScrollIntoView(fixedItem);
            }
    
            private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                //fixedItem = (string)listBox1.SelectedItem;
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                listBox1.Items.Add("item0");
                listBox1.Items.Add("item1");
                listBox1.Items.Add("item2");
                listBox1.Items.Add("item3");
                listBox1.Items.Add("item4");
                listBox1.Items.Add("item5");
                listBox1.Items.Add("item6");
    
            }
    
            private void button2_Click(object sender, RoutedEventArgs e)
            {
                fixedItem = (string)listBox1.SelectedItem;
                int selectedIndex = listBox1.SelectedIndex;
    
                listBox1.Items.Insert(0, "item7");
                listBox1.Items.Insert(0, "item8");
                listBox1.Items.Insert(0, "item9");
                listBox1.Items.Insert(0, "item10");
                listBox1.Items.Insert(0, "item11");
                listBox1.Items.Insert(0, "item12");
                listBox1.Items.Insert(0, "item13");
                listBox1.Items.Insert(0, "item14");
                listBox1.Items.Insert(0, "item15");
    
                listBox1.Items.Remove(fixedItem);
                listBox1.Items.Insert(selectedIndex, fixedItem);
                listBox1.SelectedItem = fixedItem;
            }
    
            private void button3_Click(object sender, RoutedEventArgs e)
            {
                fixedItem = (string)listBox1.SelectedItem;
                int selectedIndex = listBox1.SelectedIndex;
    
                listBox1.Items.Insert(0, "item16");
                listBox1.Items.Insert(0, "item17");
                listBox1.Items.Insert(0, "item18");
                listBox1.Items.Insert(0, "item19");
                listBox1.Items.Insert(0, "item20");
                listBox1.Items.Insert(0, "item21");
                listBox1.Items.Insert(0, "item22");
                listBox1.Items.Insert(0, "item23");
                listBox1.Items.Insert(0, "item24");
    
                listBox1.Items.Remove(fixedItem);
                listBox1.Items.Insert(selectedIndex, fixedItem);
                listBox1.SelectedItem = fixedItem;
            }
        }
    }
