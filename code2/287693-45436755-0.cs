    namespace SpeechRecognition
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
     
            private void Form1_Load(object sender, EventArgs e)
            {
                SpeechRecognizer sr = new SpeechRecognizer();
                Choices ch = new Choices();
                ch.Add(new string[] { "yes", "no","in","out" });
     
                GrammarBuilder gb = new GrammarBuilder();
                gb.Append(ch);
     
                Grammar gr = new Grammar(gb);
     
                sr.LoadGrammar(gr);
     
                sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognition);
     
            }
     
            private void sr_SpeechRecognition(object sender, SpeechRecognizedEventArgs e)
            {
                MessageBox.Show(e.Result.Text);
     
            }
        }
    }
