    public partial class FlowPanel : UserControl
    {
        public FlowPanel()
        {
            InitializeComponent();
            Load_Sample_Forms();
        }
        public void Load_Sample_Forms()
        {
            for (int i = 0; i < 5; i++)
            {
                Item_User_Control Item = new Item_User_Control();
                Item.Name = "Test Item " + i;
                Item.Price.Text = i.ToString();
                Item.button.Name = i.ToString();
                flowLayoutPanel1.Controls.Add(Item);
            }
        }
    }
