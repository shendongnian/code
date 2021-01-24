    public Form2(string text)
        {
            InitializeComponent();
            richTextBox1.Text = System.Xml.Linq.XDocument.Parse(text).ToString(); //This doesn't actually parse with your data from the query so just set it to the variable.
        }
