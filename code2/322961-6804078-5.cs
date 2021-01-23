    public partial class Form1 : Form
    {
        // keep a reference to a MyClass object for your Form's lifetime
        private MyClass _myClass;
        public Form1()
        {
            InitializeComponent();
            // Intstantiate your MyClass object so you can use it.
            _myClass = new MyClass();
            // Register to the MyClass event called UpdateLabel.
            // Anytime MyClass raises the event, your form will respond
            // by running the UpdateLabelFromMyClass method.
            _myClass.UpdateLabel += UpdateLabelFromMyClass;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Call MyMethod in your MyClass object. It will raise
            // the UpdateLabel event.
            _myClass.MyMethod();
        }
        void UpdateLabelFromMyClass(string message)
        {
            // Update your label with whatever message is passed in
            // from the MyClass.UpdateLabel event.
            label1.Text = message;
        }
    }
    public class MyClass
    {
        // An event that can be raised, allowing other classes to
        // subscribe to it and do what they like with the message.
        public event Action<string> UpdateLabel;
        public void MyMethod()
        {
            // Raise the UpdateLabel event, passing "Outside" as
            // the message.
            UpdateLabel("Outside");
        }
    }
    
