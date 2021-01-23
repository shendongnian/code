    public partial class SelectionForm : Form
    {
        public SelectionForm()
        {
            InitializeComponent();
        }
        //Selection holder
        private string _selection;
        //Public access to this item
        public string Selection { get { return _selection; } }
        private void button1_Click(object sender, EventArgs e)
        {
            _selection = "One was selected";
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _selection = "Two was selected";
            this.Close();
        }
    }
