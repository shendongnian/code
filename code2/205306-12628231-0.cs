    public partial class DualComboBoxGridViewForm : Form
    {
        private Dictionary<Country, List<City>> locations;
        public DualComboBoxGridViewForm()
        {
            InitializeComponent();
            InitializeLocations();
            dataGridView1.Rows.Add(new DataGridViewRow());
        }
        private void InitializeLocations()
        {
            // Loading these from a database would be highly recommended, I 
            // just did it like this with a dictionary to it would be easier 
            // to show.
            locations = new Dictionary<Country, List<City>>();
            List<City> americanCities = new List<City>();
            americanCities.Add(new City { ID = 0, Name = "Please Select A City" });
            americanCities.Add(new City { ID = 1, Name = "Boston" });
            americanCities.Add(new City { ID = 2, Name = "New York" });
            List<City> japaneseCities = new List<City>();
            japaneseCities.Add(new City { ID = 0, Name = "Please Select A City" });
            japaneseCities.Add(new City { ID = 1, Name = "Tokyo" });
            japaneseCities.Add(new City { ID = 2, Name = "Kyoto" });
            locations.Add(new Country { ID = 0, Name = "Please Select A Country" }, new List<City>());
            locations.Add(new Country { ID = 1, Name = "USA" }, americanCities);
            locations.Add(new Country { ID = 2, Name = "Japan" }, japaneseCities);
        }
        private void InitializeDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.EditingControlShowing += dataGridView1_EditingControlShowing;
            // Create columns
            DataGridViewTextBoxColumn eventNameColumn = new DataGridViewTextBoxColumn();
            eventNameColumn.HeaderText = "Event";
            DataGridViewComboBoxColumn countryComboBox = new DataGridViewComboBoxColumn();
            countryComboBox.Name = "Country";
            countryComboBox.HeaderText = "Country";
            countryComboBox.ValueMember = "ID";
            countryComboBox.DisplayMember = "Name";
            foreach (Country country in locations.Keys)
            {
                countryComboBox.Items.Add(country);
            }
            DataGridViewComboBoxColumn cityComboBox = new DataGridViewComboBoxColumn();
            cityComboBox.Name = "City";
            cityComboBox.HeaderText = "City";
            cityComboBox.ValueMember = "ID";
            cityComboBox.DisplayMember = "Name";
            dataGridView1.Columns.Add(eventNameColumn);
            dataGridView1.Columns.Add(countryComboBox);
            dataGridView1.Columns.Add(cityComboBox);
        }
        // Triggers when a column enters edit mode (new value not yet assigned).
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs args)
        {
            // we only want to change the city box if a country value is changed
            if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["Country"].Index)
            {
                ComboBox countryBox = args.Control as ComboBox;
                countryBox.SelectedIndexChanged += countryComboBox_SelectedIndexChanged;
            }
        }
        private void countryComboBox_SelectedIndexChanged(object sender, EventArgs args)
        {
            ComboBox box = sender as ComboBox;
            
            DataGridViewComboBoxCell cityCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[dataGridView1.Columns["City"].Index] as
                DataGridViewComboBoxCell;
            cityCell.Items.Clear();
            foreach (City city in locations[box.SelectedItem as Country])
            {
                cityCell.Items.Add(city);
            }
            if (cityCell.Items.Count > 0)
            {
                cityCell.Value = cityCell.Items[0];
            }
            // Remove event handler to prevent memory leak
            box.SelectedIndexChanged -= countryComboBox_SelectedIndexChanged;
        }
    }
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
