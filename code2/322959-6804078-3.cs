    public partial class Form1 : Form
    {
        private MyClass _myClass;
        public Form1()
        {
            InitializeComponent();
            _myClass = new MyClass();
            _myClass.UpdateLabel += UpdateLabelFromMyClass;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _myClass.MyMethod();
        }
        void UpdateLabelFromMyClass(string message)
        {
            label1.Text = message;
        }
    }
    public class MyClass
    {
        public event Action<string> UpdateLabel;
        public void MyMethod()
        {
            UpdateLabel("Outside");
        }
    }
    
