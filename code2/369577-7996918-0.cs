    public partial class MyForm2 : Form
    {
        public MyForm2(MyClass given)
        {
            InitializeComponent();
    
            given.DoSomethingElse();
        }
    }
