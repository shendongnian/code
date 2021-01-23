    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                object obj = Activator.CreateInstance(null, "WindowsFormsApplication6.TestClass");
            }
        }
    }
    
    namespace WindowsFormsApplication6
    {
        public class TestClass
        {
    
        }
    }
