    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
            }
            public string FormText
            {
                get { return textBox1.Text; }
                set { textBox1.Text = value; }
            }
        }
    }
