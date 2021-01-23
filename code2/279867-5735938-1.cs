    public partial class Form1 : Form
    {
        private List<User> usersList;
        private BindingSource source;
    
        public Form1()
        {
            InitializeComponent();
    
            usersList = new List<User>();
            usersList.Add(new User { PhoneID = 1, Name = "Fred" });
            usersList.Add(new User { PhoneID = 2, Name = "Tom" });
    
            // You can construct your BindingList<User> from the List<User>
            BindingList<User> users = new BindingList<User>(usersList);
    
            // This line binds to the BindingList<User>
            dataGridView1.DataSource = users;
            // We now create the BindingSource
            source = new BindingSource();
            // And assign the List<User> as its DataSource
            source.DataSource = usersList;
                
            // And again, set the DataSource of the DataGridView
            // Note that this is just example code, and the BindingList<User>
            // DataSource setting is gone. You wouldn't do this in the real world 
            dataGridView1.DataSource = source;
            dataGridView1.AllowUserToAddRows = true;               
    
        }
    
        // This button click event handler shows how to add a new row, and
        // get at the inserted object to change its values.
        private void button1_Click(object sender, EventArgs e)
        {
            User user = (User)source.AddNew();
            user.Name = "Mary Poppins";
        }
    }
 
