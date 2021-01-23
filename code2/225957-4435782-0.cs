    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            String s = "ABCDE\r\n" + "FGHIJ";
            MessageBox.Show(s);            
            MessageBox.Show(RemoveAndNewlineLineFeed(s));            
        }
        string RemoveAndNewlineLineFeed(string s)
        {
            String[] lf = { "\r", "\n" }; 
            return String.Join("",s.Split(lf,StringSplitOptions.RemoveEmptyEntries));             
        }
    }
