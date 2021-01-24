    namespace WindowsFormsApp8
    {
        public partial class Form1 : Form
        {
            private void Lb1SumF_Click(object sender, EventArgs e)
            {
            }
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                TX1.TabIndex=0;
            }
            private void label4_Click(object sender, EventArgs e)
            {
            }
            private void TX1_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    int sumF; 
                    //sumF = Convert.ToInt32(Lb1PriceF.Text) * Convert.ToInt32(TX1.Text); // You were doing wrong here , you were multiplying these values
                    sumF = Convert.ToInt32(Lb1PriceF.Text) + Convert.ToInt32(TX1.Text);
                    Lb1SumF.Text = Convert.ToString(sumF); //Label1 sum
                }
                catch
                {
                    Lb1SumF.Text = "0";
                }
            }
 
            private void TX2_TextChanged(object sender, EventArgs e)
            {
                try
                {
                    int sumF;
                    //sumF = Convert.ToInt32(Lb2PriceF.Text) * Convert.ToInt32(TX2.Text); //you are doing it wrong here , you are multiplying
                    sumF = Convert.ToInt32(Lb2PriceF.Text) + Convert.ToInt32(TX2.Text);
                    Lb2SumF.Text = Convert.ToString(sumF); //Label2 sum
                }
                catch
                {
                    Lb2SumF.Text = "0";
                }
            }
            private void Lb3_TextChanged(object sender, EventArgs e)
            {
                   int i = Convert.ToInt32(Lb1SumF.Text);
                   int j = Convert.ToInt32(Lb2SumF.Text);
                   Lb3.Text = Convert.ToString(i+j); // Label3 sum 
            }
            private void Lb3SumF_Click(object sender, EventArgs e)
            {
            }
       }
    }
