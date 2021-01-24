    public partial class Item_User_Control : UserControl
    {
        public event EventHandler ItemClicked; // Event to notify the item getting clicked.
        public Item_User_Control()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, EventArgs e)
        {
            // When the button gets clicked, raise the ItemClicked event.
            ItemClicked?.Invoke(this, EventArgs.Empty);
        }
    }
