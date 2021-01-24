    ListView listView;
    string[] items;
    ItemSelectedAdapter itemSelectedAdapter;
    Button editButton;
    
    
    listView = FindViewById<ListView>(Resource.Id.listView1);
    items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
    itemSelectedAdapter= new ItemSelectedAdapter(this, items);
    listView.Adapter = itemSelectedAdapter;
    listView.ItemClick += ListView_ItemClick;
    editButton= FindViewById<Button>(Resource.Id.button2);
    editButton.Click += Button2_Click;
    
    private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
    {
        itemSelectedAdapter.setSelectItem(e.Position);
        Console.WriteLine("selected is：" + e.Position);
        itemSelectedAdapter.NotifyDataSetChanged();
    }
    private void Button2_Click(object sender, EventArgs e)
    {
        int selectItemID = (int)homeScreenAdapter.selectItem;
        Console.WriteLine("selected is：" + selectItemID);
        items[selectItemID] = atv_content.Text;
        homeScreenAdapter.NotifyDataSetChanged();
     }
