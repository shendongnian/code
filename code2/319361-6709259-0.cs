    public partial class Form1 : Form
    {
        Dictionary<Keys, Action<object, KeyEventArgs>> KeyPressLookup;
        public Form1()
        {
            KeyPressLookup = new Dictionary<Keys, Action<object, KeyEventArgs>>();
            KeyPressLookup[Keys.F10] = (o, e) => MessageBox.Show("You pressed F10");
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(KeyPressLookup.ContainsKey(e.KeyCode) // Could use TryGetValue instead
                KeyPressLookup[e.KeyCode](sender, e);
        }
    }
