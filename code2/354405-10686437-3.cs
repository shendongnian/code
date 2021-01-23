    public partial class Form2 : Form
    {
        public string Id = string.Empty;
        public Form2(string FormOneID)
        {
            InitializeComponent();
            Id = FormOneID;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("FormOne ID" + Environment.NewLine + Id + Environment.NewLine + "Displaying on FormTwo");
        }
    }
