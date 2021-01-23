    public partial class Form1 : Form { 
    
       public Form1() { InitializeComponent(); }
    
        private void form1_button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            f2.SomeTextInSomeFormChanged +=new EventHandler(f2_SomeTextInSomeFormChanged);  
        }
    
        public void f2_SomeTextInSomeFormChanged(object sender, EventArgs e)
        {
            var textBoxFromForm2 = (TextBox)sender;
            form1_textBox1.Text =  textBoxFromForm2.Text
            this.Focus();
        }
    }
