    private BindingList<CheckedListBoxItem> list = new BindingList<CheckedListBoxItem>();
    private void Form1_Load(object sender, EventArgs e)
    {
        list.Add(new CheckedListBoxItem("A"));
        list.Add(new CheckedListBoxItem("B"));
        list.Add(new CheckedListBoxItem("C"));
        list.Add(new CheckedListBoxItem("D"));
        checkedListBox1.DataSource = list;
        checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
        list.ListChanged += List_ListChanged;
    }
    private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        ((CheckedListBoxItem)checkedListBox1.Items[e.Index]).CheckState = e.NewValue;
    }
    private void List_ListChanged(object sender, ListChangedEventArgs e)
    {
        for (var i = 0; i < checkedListBox1.Items.Count; i++)
        {
            checkedListBox1.SetItemCheckState(i,
                ((CheckedListBoxItem)checkedListBox1.Items[i]).CheckState);
        }
    }
