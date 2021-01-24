    public partial class Form2 : Form
        {
            public string PubId { get; set; }
    
            public Form2()
            {
                InitializeComponent();
            }
            
            private void button1_Click(object sender, EventArgs e)
            {
                PubId = "8";
            }
        }
