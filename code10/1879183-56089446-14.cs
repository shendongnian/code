    public partial class Form1 : SuperForm
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {   
            // you dont have to use polymorphism...
            SuperForm f = new Form2();
            f.Show();
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            // you dont have to use polymorphism...
            SuperForm f = new Form3();
            f.Show();
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            // show all the forms that are active
            foreach (var frm in AppForms.AppFormsList)
            {
                MessageBox.Show(((SuperForm)frm).isFormActive.ToString());
            }
        }
    }
