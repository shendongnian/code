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
                    int _score = int.TryParse(textBox1.Text, out int converted) ? converted: 0; // Correct Way Of Handling As Mentioned In Comments
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
