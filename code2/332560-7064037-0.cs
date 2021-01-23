    public partial class Form2 : Form
    {
        private BindingClass backingClass;
    
        public Form2()
        {
            InitializeComponent();
    
            backingClass = new BindingClass();
            backingClass.Name = "Hippo";
            backingClass.One = true;
    
            textBox1.DataBindings.Add("Text", backingClass, "Name");
    
            radioButton1.DataBindings.Add("Checked", backingClass, "One");
            radioButton2.DataBindings.Add("Checked", backingClass, "Two");
            radioButton3.DataBindings.Add("Checked", backingClass, "Three");
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(backingClass.Name);
            if (backingClass.One)
            {
                MessageBox.Show("One");
            }
            if (backingClass.Two)
            {
                MessageBox.Show("Two");
            }
            if (backingClass.Three)
            {
                MessageBox.Show("Three");
            }
        }
    }
    
    public class BindingClass
    {
        private bool one;
        private bool two;
        private bool three;
    
        public string Name { get; set; }
    
        public bool One {
            get { return one;}
            set
            {
    
                    one = value;
                    two = !value;
                    three = !value;           
            }
        }
        public bool Two
        {
            get { return two; }
            set
            {
    
                two = value;
                one = !value;
                three = !value;    
            }
        }
        public bool Three
        {
            get { return three; }
            set
            {
    
                three = value;
                one = !value;
                two = !value;    
            }
        }
    }
