    public partial class Form1 : Form
    {
        private const string FilePath = @"f:\private\temp\temp.txt";
        public Form1()
        {
            InitializeComponent();
            // Create a file with 20,000 lines
            var fileLines = new List<string>(20000);
            for (int i = 0; i < 20000; i++)
            {
                fileLines.Add($"This is line number {i + 1}.");
            }
            File.WriteAllLines(FilePath, fileLines);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Test loading with ReadAllText
            richTextBox1.Text = string.Empty;
            var sw = Stopwatch.StartNew();
            richTextBox1.Text = File.ReadAllText(FilePath);
            sw.Stop();
            Debug.WriteLine("ReadAllText = " + sw.ElapsedMilliseconds);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Test loading with ReadLines and string.Join
            richTextBox1.Text = string.Empty;
            var sw = Stopwatch.StartNew();
            List<string> lines = new List<string>();
            lines.AddRange(File.ReadAllLines(FilePath));         
            richTextBox1.Text = string.Join(Environment.NewLine, lines);
            sw.Stop();
            Debug.WriteLine("ReadLines + string.Join = " + sw.ElapsedMilliseconds);
        }
    }
