    public partial class Grafic : Control
    {
        private SortedDictionary<int, int> WordLengthCounts = new SortedDictionary<int, int>();
        public Grafic()
        {
            InitializeComponent();
            this.DragEnter += Grafic_DragEnter;
            this.DragDrop += Grafic_DragDrop;
            this.Paint += Grafic_Paint;
        }
        private void Grafic_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(typeof(string)) ? DragDropEffects.All : DragDropEffects.None;
        }
        private void Grafic_DragDrop(object sender, DragEventArgs e)
        {
            string input = (string)e.Data.GetData(typeof(string));
            // Regex by TheCodeKing: https://stackoverflow.com/a/7311811/2330053
            var matches = System.Text.RegularExpressions.Regex.Matches(input, @"((\b[^\s]+\b)((?<=\.\w).)?)");
            foreach (var match in matches)
            {
                int wordLength = match.ToString().Length;
                if(!WordLengthCounts.ContainsKey(wordLength))
                {
                    WordLengthCounts.Add(wordLength, 1);
                }
                else
                {
                    WordLengthCounts[wordLength]++;
                }
            }
            this.Invalidate();
        }
        private void Grafic_Paint(object sender, PaintEventArgs e)
        {
            Graphics G = e.Graphics;
            foreach(var wordLengthCount in WordLengthCounts)
            {
                Console.WriteLine("Length: " + wordLengthCount.Key.ToString() + ", Count: " + wordLengthCount.Value.ToString());
                // ... put in your drawing code to visualize this data ...
            }
        }
    }
