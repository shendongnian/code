    using TestFormsApp_Different
    
    namespace TestFormsApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Form2 newForm = new Form2();
                newForm.Show();
            }
        }
    }
