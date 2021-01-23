        public Form1()
        {
            InitializeComponent();
            string text = "qwerty\nasdfgh\nzxcvbn";
            richTextBox1.Text = text;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //change ever 3rd charater in each line:
            string[] words = richTextBox1.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            richTextBox1.Text = "";
            for (int i = 0; i < words.Length; i++)
            {
                char[] chars = words[i].ToCharArray();
                chars[2] = Convert.ToChar(chars[2].ToString().ToUpper());
                string newWord = new string(chars);
                richTextBox1.AppendText(newWord + "\n");
            }
        }
