     public partial class Form1 : Form
     {
         public Form1()
         {
              InitializeComponent();
         }
         public string ComboBox1Text
         {
              get { return comboBox1.Text; }
         }
        public string TextBox1Text
        {
             get { return textBox1.Text; }
             set { textBox1.Text = value; }
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
              Class1 class1 = new Class1();
              class1.FunctionSelect();
        }
