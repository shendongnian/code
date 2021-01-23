    public partial class Form1 : Form
    {
        public BindingList<ABC> myBindingList = new BindingList<ABC>();
    
        public Form1() {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e) {
            myBindingList.Add(new ABC("zzz"));
            myBindingList.Add(new ABC("aaa"));
        }
    
        private void button2_Click(object sender, EventArgs e) {
            myBindingList[0].MyField = "ccc"; // was "zzz"
            myBindingList[1].MyField = "ddd"; // was "aaa"
    
            listBox1.DataSource = null;
            listBox1.DataSource = myBindingList;
            listBox1.DisplayMember = "MyField";
        }
    
        private void Form1_Load(object sender, EventArgs e) {
            listBox1.DataSource = myBindingList;
            listBox1.DisplayMember = "MyField";
    
        }
    }
    
    public class ABC  {
        public string MyField { get; set; } 
        public ABC(string val) {
            MyField = val;
        }
    }
