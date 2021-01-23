    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BindingList<User> users = new BindingList<User> { new User() { UserName = "Fred", userid = 2 } };
            IList<MyValue> values = new List<MyValue> { new MyValue{id = 1, name="Fred"}, new MyValue{id = 2, name="Tom"}};
            dataGridView1.DataSource = users;
            
            DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
            col.DataSource = values;
            col.DisplayMember = "name";
            col.DataPropertyName = "userid";
            col.ValueMember = "id";
            dataGridView1.Columns.Add(col);
  
        }       
    }
    public class MyValue
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class User
    {
        public string UserName { get; set; }
        public int userid {get;set;}
    }
