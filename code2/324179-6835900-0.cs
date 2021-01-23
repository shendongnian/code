    public partial class Form1 : Form
    {
        ArrayList alcar = new ArrayList(); // DO THIS HERE!
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text; ; int quantity = int.Parse(textBox2.Text);
            car c = new car(name, quantity);
            //JUST ADD - without checking for null!
            alcar.Add(c);
            Form2 f2 = new Form2();
            f2.Show();
        }
        public ArrayList getArray()
        {
             return alcar; //its non-null - guaranteed!
        }
        //...
     }
