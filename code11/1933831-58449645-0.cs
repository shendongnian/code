     public partial class Form1 : Form
    {
        public BindingList<Entrys> Personallist = new BindingList<Entrys>();
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Personallist;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Number";
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            Personallist.Add(new Entrys() { Name = "TESTNAME", Number = "TESTNR" });
        }
    }
    public partial class Entrys
    {
        public string Name { get; set; }
        public string Number { get; set; }
    }
