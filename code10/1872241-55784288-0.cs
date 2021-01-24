    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void DoSomething()
        {
            Pet cat = new Pet("10", "Fido", "Cat");
            cat.GetName();
        }
    }
