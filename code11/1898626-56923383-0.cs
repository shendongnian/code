    public partial class Form1 : Form
    {
        private Dictionary<string, string> countryCodes = new Dictionary<string, string>()
        {
            { "Albania", "Albania +355" },
            { "USA", "USA +1" },
            { "Iran", "Iran +98" },
        };
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            comboBox1.Items.AddRange(countryCodes.Values.ToArray());
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = countryCodes.Where(x => x.Value == comboBox1.SelectedItem.ToString()).First().Key;
        }
    }
