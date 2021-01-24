    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
       
    
        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "00/0000000";
    
            maskedTextBox1.MaskInputRejected += new MaskInputRejectedEventHandler(maskedTextBox1_MaskInputRejected);
        }
        void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
             if (!maskedTextBox1.Text.StartsWith("00")) 
            {
                MessageBox.Show("You must input start with 00");
            }
            else if (maskedTextBox1.Text == "00/0000000") 
            {
                MessageBox.Show("You can not input all number is 0");//
            }
            else if (maskedTextBox1.MaskFull)   
            {
                 MessageBox.Show("You cannot enter any more data into the date field. Delete some characters in order to insert more data.");
            }
        }
    }
