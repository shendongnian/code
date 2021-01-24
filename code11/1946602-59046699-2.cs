    public partial class Main : Form
    {
        public static Main Instance { get; private set; }
        public Main()
        {
            InitializeComponent();
            Instance = this; // Initiate an instance of your form
        }
        public void Load_Main_Function()
        {
            MessageBox.Show("I'm called from the User Control inside flowpanellayout");
        }
    }
