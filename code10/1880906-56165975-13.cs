    public class FrmMasterItem : Form, ISearch
    {
        public FrmMasterItem() => InitializeComponent();
        // Interface implementation
        public string Query { get; private set; }
        public int Other { get ; private set; }
        public bool ReturnValue { get; set; }
        public string GetSomeOtherValue()
        {
            return "SomeValue";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Query = "SELECT someField FROM someTable";
            this.Other = 100;
            var search = new SearchForm();
            search.ShowDialog(this);
            if (this.ReturnValue)
                Console.WriteLine("All Good");
        }
    }
