    namespace Passing_values_from_one_form_to_other
    {
           
     public partial class Form2 : Form
    
        {
             private string str;
            public string passvalue
            {
                get { return  str; }
                set { str = value; }
            }
        
            public Form2()
            {
                InitializeComponent();
            }
    
            private void Btn_Ok1_Click(object sender, EventArgs e)
            {
    
                passvalue = textBox1.Text;
                this.Close();
            }
        }
    }
