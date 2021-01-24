    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var person = new Person();
            person.Name = txtName.Text;
            if (int.TryParse(txtAge.Text, out int age))
            {
                person.Age = age;
            }
            var form2 = new SecondForm(person);
            form2.Show();
        }
    }
