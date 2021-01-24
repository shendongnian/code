    class MyValues
    {
        public string aa { get; set; }
        public string AA { get; set; }
        public string Aa { get; set; }
        public string aA { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<MyValues> list = new List<MyValues>();
        private void Button1_Click(object sender, EventArgs e)
        {
            list.Add(new MyValues { aa = "BB", AA = "Bb", Aa = "bB", aA = "bb" });
            dataGridView1.DataSource = list;
        }
    }
