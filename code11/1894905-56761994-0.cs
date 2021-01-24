    public partial class Form1 : Form
    {
        private readonly List<string> _coll = new List<string> { "aaaaa", "bbbbb", "ccccc" };
        private readonly BindingList<string> _blist;
        private readonly Random _rand = new Random();
        private const string Templ = "mcvnoqei4yutladfffvtymoiaro875b247ytmlarkfhsdmptiuo58y1toye";
        public Form1()
        {
            InitializeComponent();
            _blist = new BindingList<string>(_coll);
            comboBox1.DataSource = _blist;
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            int i = _rand.Next(Templ.Length - 5);
            string s = Templ.Substring(i, 5);
            _blist.Add(s);
        }
    }
