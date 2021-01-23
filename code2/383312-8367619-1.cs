     public partial class Form7 : Form
     {
        private TextBox textBox = null;
        public Form7()
        {
            InitializeComponent();
    
            // Binding to custom event process function GetF.
            this.textBox1.GotFocus += new EventHandler(GetF);
            this.textBox2.GotFocus += new EventHandler(GetF);
        }
    
        private void GetF(object sender, EventArgs e)
        {
            // Keeps you selecting textbox object reference.
            textBox = sender as TextBox;
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            // Changes you text box text.
            if (textbox != null) textBox.SelectedText += "You text";
        }
    }
