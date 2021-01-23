    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
            radioButton1.TabStop = false;
            radioButton2.TabStop = false;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.TabStop = false;
            radioButton2.TabStop = false;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.TabStop = false;
            radioButton2.TabStop = false;
        }
        
    }
        
