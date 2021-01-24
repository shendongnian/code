    public partial class Form1 : Form
    {
        int total = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void PresentQuestion()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            Random rand = new Random();
            int cycles = rand.Next(1, 4);
            
            switch (cycles)
            {
                case 1:
                    textBox1.Text = "what is 15 - 8 ?";
                    total = 15 - 8;
                    radioButton1.Text = "6";
                    radioButton2.Text = "7";
                    radioButton3.Text = "5";
                    radioButton4.Text = "4";
                    break;
                case 2:
                    textBox1.Text = "what is 5 x 5?";
                    total = 5 * 5;
                    radioButton1.Text = "25";
                    radioButton2.Text = "50";
                    radioButton3.Text = "20";
                    radioButton4.Text = "100";
                    break;
                case 3:
                    textBox1.Text = "what is 2+2?";
                    total = 2 + 2;
                    radioButton1.Text = "4";
                    radioButton2.Text = "2";
                    radioButton3.Text = "2";
                    radioButton4.Text = "8";
                    break;
            }
        }
        private bool CheckOFResult()
        {
            foreach(Control r in this.Controls)
            {
                if(r.GetType() == typeof(RadioButton))
                {
                    RadioButton radio = (RadioButton)r;
                    if (radio.Checked)
                    {
                        if (int.Parse(radio.Text) == total)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PresentQuestion();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckOFResult())
            {
                MessageBox.Show("Correct");
            }else
            {
                MessageBox.Show("Incorrect");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PresentQuestion();
        }
    }
