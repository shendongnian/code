    public partial class Form1 : Form                    
    {             
        Customer customer = new Customer();             
        public Form1()             
        {             
            InitializeComponent(); 
            customer.FillNames();
            richTextBox1.Text = customer.Names;                        
        }   
     }
 
