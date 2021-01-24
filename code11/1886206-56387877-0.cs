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
            Class1 class1 = new Class1(this);
            class1.FunctionSelect();
        }
    }
   
    public class Class1
    {
        private Form1 _instance;
        public Class1(Form1 instance)
        {
            _instance = instance;
        }
        public void FunctionSelect()
        {
            string switcher = _instance.ComboBox1Text;
            switch (switcher)
            {
                case "1":
                    _instance.TextBox1Text = "1 was selected";
                    break;
                case "2":
                    _instance.TextBox1Text = "2 was selected";
                    break;
                case "3":
                    _instance.TextBox1Text = "3 was selected";
                    break;
                case "4":
                    _instance.TextBox1Text = "4 was selected";
                    break;
                case "5":
                    _instance.TextBox1Text = "5 was selected";
                    break;
            }
        }
    }
