    public partial class Form1 : Form
    {
        private string path = @"D:\temp\test.txt";
        private List<string> _lines;
        private int _currentLineIndex;
        public Form1()
        {
            InitializeComponent();
            // if you're adding these using a reader then 
            // you need to initialize the List first...
            _lines = new List<string>();
            _lines = System.IO.File.ReadAllLines(path).ToList();
            CurrentLineIndex = 0;
        }
    }
