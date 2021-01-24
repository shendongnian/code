    public partial class Form1 : Form
    {
        private BindingSource _source = new BindingSource();
        List<person> _person = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _person = new List<person>();
            _person.Add(new person {ID = 1, Name = "Tridip"});
            _person.Add(new person {ID = 2, Name = "Sujit"});
            _person.Add(new person {ID = 3, Name = "Arijit"});
            _source.DataSource = _person;
            dgLogList.DataSource = _source;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dvr in dgLogList.SelectedRows)
            {
                if (dvr != null)
                {
                    dgLogList.Rows.Remove(dvr);
                    dgLogList.Refresh();
                }
            }
        }
    }
    public class person
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
