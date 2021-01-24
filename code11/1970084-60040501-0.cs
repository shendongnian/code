     public partial class Form1 : Form
        {
            List<int> _scores = new List<int>();
            int average = 0;
            int quizScore = 0;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
    
                try
                {
                    int _score = Convert.ToInt32(textBox1.Text);
                    _scores.Add(_score);
                    listBox1.Items.Add(_score);
                    textBox1.Text = null;
    
                    average = (int)_scores.Average();
                    quizScore = _scores.Sum();
    
                    label1.Text = $"Score: {quizScore}";
                    label2.Text = $"Average: {average}";
    
                }
                catch (Exception ex)
                {
    
                    MessageBox.Show(ex.ToString());
                }
            }
        }
