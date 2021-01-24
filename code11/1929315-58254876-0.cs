    Try this ...
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int cycles = 0;
        private void PresentQuestion(int cycles)
        {
            switch (cycles)
            {
                case 1:
                    textBox1.Text = "what is 15 - 8 ?";
                    radioButton1.Text = "A. 6";
                    radioButton2.Text = "B. 7";
                    radioButton3.Text = "C. 5";
                    radioButton4.Text = "D. 4";
                    break;
                case 2:
                    textBox1.Text = "what is 5 x 5?";
                    radioButton1.Text = "A. 25";
                    radioButton2.Text = "B. 50";
                    radioButton3.Text = "C. 20";
                    radioButton4.Text = "D. 100";
                    break;
                case 3:
                    textBox1.Text = "what is 2+2?";
                    radioButton1.Text = "A. 4";
                    radioButton2.Text = "B. 2";
                    radioButton3.Text = "C. 2";
                    radioButton4.Text = "D. 8";
                    break;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            switch (cycles)
            {
                case 1:
                    if(radioButton2.Checked)
                    {
                        MessageBox.Show("correct");
                    }
                    else
                    {
                        MessageBox.Show("wrong");
                    }
                    break;
                case 2:
                    if (radioButton1.Checked)
                    {
                        MessageBox.Show("correct");
                    }
                    else
                    {
                        MessageBox.Show("wrong");
                    }
                    break;
                case 3:
                    if (radioButton1.Checked)
                    {
                        MessageBox.Show("correct");
                    }
                    else
                    {
                        MessageBox.Show("wrong");
                    }
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            Random rand = new Random();
            cycles = rand.Next(1, 4);
            PresentQuestion(cycles);
        }
    }
