    public partial class Form2 : Form
    {
        public string data = string.Empty;
        public Form2()
        {
            InitializeComponent();
            listView1.ItemDrag += doDaragItem;
        }
    
        private void doDaragItem(Object sender, ItemDragEventArgs e)
        {
            data = e.Item.ToString();
        }
    }
