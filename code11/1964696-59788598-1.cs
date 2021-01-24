    public partial class MainWindow : Form
    {
        private List<string> _randomStrings = new List<string>();
        private Random _rnd = new Random(DateTime.UtcNow.Millisecond);
        public MainWindow()
        {
            InitializeComponent();
            _randomStrings.Add("Abcd");
            _randomStrings.Add("Water");
            _randomStrings.Add("Moon");
            _randomStrings.Add("Pizza");
            _randomStrings.Add("Winter");
            _randomStrings.Add("Orange");
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            // determine the rollcount. (some initial rolls for the rolling effect)
            int rollCount = 50 + _rnd.Next(_randomStrings.Count);
            int index = 0;
            // roll it.......
            for (int i = 0; i < rollCount; i++)
            {
                // just use a modulo on the i to get an index which is inside the list.
                index = i % _randomStrings.Count;
                // display the current item
                label1.Text = _randomStrings[index];
                // calculate a delay which gets longer and longer each roll.
                var delay = (250 * i / rollCount);
                // wait some. (but don't block the UI)
                await Task.Delay(delay);
            }
            MessageBox.Show($"and.... The winner is... {_randomStrings[index]}");
        }
    }
