    using System.Windows.Forms;
    
    namespace WindowsFormsApplication
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                comboBox.Items.Add(new User(1, "Dan"));
                comboBox.Items.Add(new User(2, "Peter"));
                comboBox.Items.Add(new User(3, "David"));
    
                comboBox.SelectedIndexChanged += new System.EventHandler(ComboBoxSelectedIndexChanged);
            }
    
            void ComboBoxSelectedIndexChanged(object sender, System.EventArgs e)
            {
                ComboBox combo = (ComboBox)sender;
                User user = (User)combo.SelectedItem;
                MessageBox.Show("User Id = " + user.Id.ToString() + ",  Name" + user.Name);   
            }
        }
    
        public class User
        {
            public long Id { get; private set; }
            public string Name { get; private set; }
    
            public User(long id, string name)
            {
                Id = id;
                Name = name;
            }
    
            public override string ToString()
            {
                return Name;
            }
        }
    }
