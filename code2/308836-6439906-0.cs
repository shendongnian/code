    ObservableCollection<Class_ListViewItem> List_ListBoxItems = new ObservableCollection<Class_ListViewItem>();
    public YourControl() {
        InitializeComponent();
        ListBox_BinsRegion.DataContext = List_ListBoxItems;
    }
    private void Button_Add_Click(object sender, RoutedEventArgs e)
    {
        Class_ListViewItem item = new Class_ListViewItem();
        item.WH = this.comboBox_WareHouseBinsRegionDefinition.SelectedItem.ToString();
        item.XXFrom = textBox_XXFrom.Text;
        item.XXTo = textBox_XXTo.Text;
        item.YYFrom = textBox_YYFrom.Text;
        item.YYTo = textBox_YYTO.Text;
        item.Z = textBox_ZFrom.Text;
        List_ListBoxItems.Add(item);
    }
