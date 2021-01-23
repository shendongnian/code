    public partial class Form1 : Form
    {
        BindingList<Address> list;
        public Form1()
        {
            InitializeComponent();
            list = new BindingList<Address>();
            //lets add some example data:
            list.Add(new Address{ City = "London", Street = "Street 111" });
            list.Add(new Address { City = "Barcelona", Street = "Street 222" });
            comboBox1.DataSource = list;
            //I am not sure what you want to show (and what to use as a value). You can change this!
            comboBox1.DisplayMember = "Street";
            comboBox1.ValueMember = "City";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //adding new object to the list:
            string _city = textBox1.Text;
            string _street = textBox2.Text;
            if (_city != String.Empty && _street != String.Empty)
            {
                list.Add(new Address { City = _city, Street = _street });
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
    class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
