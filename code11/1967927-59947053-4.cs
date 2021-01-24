     public partial class Form1 : Form
    {
        Form2 localfrm2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
                Form2 frm2 = new Form2();
                frm2.FormClosed += Frm2_FormClosed;
            localfrm2 = frm2;
                frm2.Show();
           
        }
        private void Frm2_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show(localfrm2.PubId);
        }
    }
    
    Form 2 :
    
      public partial class Form2 : Form
    {
        public string PubId { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            PubId = textBox1.Text;
        }
    }
