    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            button1.Click += button1_Click;
            Console.SetOut(new MyLogger(richTextBox1));
        }
        class MyLogger : System.IO.TextWriter {
            private RichTextBox rtb;
            public MyLogger(RichTextBox rtb) { this.rtb = rtb; }
            public override Encoding Encoding { get { return null; } }
            public override void Write(char value) {
                if (value != '\r') rtb.AppendText(new string(value, 1));
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            Console.WriteLine(DateTime.Now);
        }
    }
