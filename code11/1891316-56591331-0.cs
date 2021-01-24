    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "Loading data...";
            LoadData();
        }
        private async void LoadData()
        {
            string text = null;
            await Task.Run(() =>
            {
                text = File.ReadAllText("z:\\123_Bank_Charge.zip");
            });
            this.textBox1.Text = text;
        }
    }
