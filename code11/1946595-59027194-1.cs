    public partial class FlowPanel : UserControl
    {
        public event EventHandler FlowItemClicked; // Event to notify any item getting clicked.
        public FlowPanel()
        {
            InitializeComponent();
        }
        public void Load_Sample_Forms()
        {            
            for (int i = 0; i < 5; i++)
            {
                Item_User_Control Item = new Item_User_Control();
                Item.Name.Text = "Test Item " + i;
                Item.Price.Text = i;
                Item.button.Name = i; 
                // Handle FlowItemClicked event from this item.
                item.ItemClicked += () => { FlowItemClicked?.Invoke(this, EventArgs.Empty;) };
                flowLayoutPanel1.Controls.Add(Item);
            }
        }
    }
