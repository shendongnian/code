    public Form1()
    {
        InitializeComponent();
       
        ListViewItem item1;
    
        int i = 1;
        while (i < 6)
        {
            item1 = new ListViewItem();
            item1.Text = "Item" + i.ToString();
            item1.Tag = new List<string>();
            listView1.Items.Add(item1);
    
            i++;
        }
    
        i = 1;
        while (i < 6)
        {
            item1 = new ListViewItem();
            item1.Text = "Filter" + i.ToString();
            listView2.Items.Add(item1);
    
            i++;
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        List<string> temp = (List<string>)listView1.SelectedItems[0].Tag;
    
        temp.Add(listView2.SelectedItems[0].Text);
    
        listView1.SelectedItems[0].Tag = temp;
     }
