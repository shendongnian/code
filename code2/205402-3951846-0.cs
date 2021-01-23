    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            outputTextBox.Text = "";
            Regex regex = new Regex("(<!--RegionStart url=\"http://(.*?)\"-->)(.*?)(<!--RegionFinish-->)", RegexOptions.Singleline);
            string copy = inputTextBox.Text;
            MatchCollection coll = regex.Matches(inputTextBox.Text);                
            outputTextBox.Text = regex.Replace(copy, new MatchEvaluator(Replace));
        }
        public string Replace(Match m)        
        {
            // Format the text you want to get back:
            return String.Format("{0}{1} {2}{3}", 
                m.Groups[1].ToString() + Environment.NewLine, 
                m.Groups[3].ToString().Replace("some", "all").Trim(),
                m.Groups[2].ToString().Trim() + Environment.NewLine, 
                m.Groups[4].ToString());
        }
    }
