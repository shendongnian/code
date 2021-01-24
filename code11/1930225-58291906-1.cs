    public partial class SecondForm : Form
    {
        public Person Person { get; set; }
        public SecondForm(Person person)
        {
            InitializeComponent();
            Person = person;
        }
        private void SecondForm_Load(object sender, EventArgs e)
        {
            lblName.Text = Person.Name;
            lblAge.Text = Person.Age.ToString();
        }
    }
