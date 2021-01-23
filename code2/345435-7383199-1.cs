    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClassA a = new ClassA();
            a.Finished += delegate(object sender, EventArgs e)
            {
                ClassB b = new ClassB();
                b.DoWork();
            };
            a.Animate();
        }
    }
