    public partial class Form1 : Form
    {
        Pet cat = new Pet("10", "Fido", "Cat");
        public Form1()
        {
            InitializeComponent();
        }
        public void DoSomething()
        {
            cat.GetName();
        }
    }
