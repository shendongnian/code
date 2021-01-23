    namespace Passing_values_from_one_form_to_other    
    {
            
        public partial class Form1 : Form
        {
            string str;
            private String value1;//taking values from form no _of_test_cases
    
            public string value
            {
                get { return value1; }
                set { value1 = value; }
            }
    
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                
                
                textBox1.Text = str;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 f2 = new Form2();
                f2.ShowDialog();
                str = f2.passvalue;
            }
        }
    }
