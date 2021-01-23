    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            MyListItem item1 = new MyListItem("Java", 1);
            MyListItem item2 = new MyListItem("C#", 221);
            MyListItem item3 = new MyListItem("C++", 13);
    
            listBox1.Items.Add(item1);
            listBox1.Items.Add(item2);
            listBox1.Items.Add(item3);
        }
    
        private class MyListItem
        {
            public string ItemName { get; set; }
            public int ItemId { get; set; }
            public MyListItem(string name, int id)
            {
                this.ItemName = name;
                this.ItemId = id;
            }
    
            public override string ToString()
            {
                return this.ItemName;
            }
        }
    
    
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyListItem selectedItem = (MyListItem)listBox1.SelectedItem;
            MessageBox.Show(string.Format("Name is: {0}, Id is: {1}", selectedItem.ItemName, selectedItem.ItemId));
        }
    }
