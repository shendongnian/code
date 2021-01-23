    public partial class Form1 : Form
    {
        bool click = false;
    
        public Form1()
        {
            InitializeComponent();
    
            List<Country> countries = new List<Country> { new Country{ CountryId = 1, Name = "UK"},  
                                    new Country{ CountryId = 2, Name = "Australia"},   
                                    new Country{ CountryId = 3, Name = "France"} };
    
            comboBox1.DataSource = countries;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "CountryId";
            comboBox1.SelectedValue = 2;
        }
    }
    
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
    }
