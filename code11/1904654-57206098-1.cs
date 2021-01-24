    class Class1
    {
        public int EntryID { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public override string ToString()
        {
            return NameFirst;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            list.SelectionMode = SelectionMode.Multiple;
            //fill list with dummy items
            var items = new Class1[10];
            for(int i = 0; i < 10; ++i)
                items[i] = new Class1() { EntryID = i, NameFirst = ((char)('A' + (char)i)).ToString() };
            list.ItemsSource = items;
            //simulate second API call
            var selection = new Class1[3];
            selection[0] = new Class1() { EntryID = 3 };
            selection[1] = new Class1() { EntryID = 4 };
            selection[2] = new Class1() { EntryID = 8 };
            list.SelectedItems.Clear();
            foreach (var sel in selection)
                foreach (var item in items.Where(i => i.EntryID == sel.EntryID))
                    list.SelectedItems.Add(item);
        }
    }
