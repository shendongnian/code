    public partial class Item_User_Control : UserControl
    {
        public Item_User_Control()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            Main.Instance.Load_Main_Function(); // Execute any main function regardless of signature;
        }
    }
