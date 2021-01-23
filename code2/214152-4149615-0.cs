    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            decimal? a = null;
            if (a < .8m)
            {
                MessageBox.Show("Less Than");
            }
            else if (a >= .8m)
            {
                MessageBox.Show("Greater Than or equal to");
            }
            else
            {
                MessageBox.Show("Neither");
            }
        }
    }
