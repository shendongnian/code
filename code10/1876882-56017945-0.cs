       public Form1()
        {
            InitializeComponent();
            _answers.Add("It is certain.");
            _answers.Add("It is decidedly so.");
            _answers.Add("Without a doubt.");
        }
        List<string> _answers = new List<string>();
            
        private void BtnRandom_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetAnswer());
            
        }
        string GetAnswer()
        {
            Random rnd = new Random();
            int i = 0;
            int _rnd = rnd.Next(_answers.Count);
            foreach (string answer in _answers)
            {
                if (i == _rnd)
                {
                    return answer;
                }
                i++;
            }
            return "";
        }
    }
