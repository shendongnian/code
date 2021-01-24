    private BindingList<string> clbItemsList = new BindingList<string>();
    public MyForm()
    {
        InitializeComponent();
        clbItemsList.Add("A");
        // (...)
        checkedListBox1.DataSource = clbItemsList;
        clbItemsList.ListChanged += this.clbListChanged;
        checkedListBox1.ItemCheck += (s, e) => { BeginInvoke(new Action(()=> CheckedStateCurrent())); };
    }
    private void clbListChanged(object sender, ListChangedEventArgs e)
    {
        foreach (var item in clbCheckedItems.ToArray()) {
            if (e.ListChangedType == ListChangedType.ItemAdded) {
                checkedListBox1.SetItemCheckState(item.Index >= e.NewIndex ? item.Index + 1 : item.Index, item.State);
            }
            if (e.ListChangedType == ListChangedType.ItemDeleted) {
                if (item.Index == e.NewIndex) { 
                    clbCheckedItems.Remove(item);
                    continue;
                }
                checkedListBox1.SetItemCheckState(item.Index > e.NewIndex ? item.Index - 1 : item.Index, item.State);
            }
        }
    }
    private List<(CheckState State, int Index)> clbCheckedItems = new List<(CheckState State, int Index)>();
    private void CheckedStateCurrent()
    {
        clbCheckedItems = checkedListBox1.CheckedIndices.OfType<int>()
            .Select(item => (checkedListBox1.GetItemCheckState(item), item)).ToList();
    }
