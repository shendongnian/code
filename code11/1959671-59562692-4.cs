    public Form2(string text)
        {
            InitializeComponent();
            richTextBox1.Text = System.Xml.Linq.XDocument.Parse(text).ToString();
        }
