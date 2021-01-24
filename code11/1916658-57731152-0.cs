    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.DisplayMember = "CityName";
            comboBox1.ValueMember = "CityValue";
            comboBox1.DataSource = ListOfCities();
        }
        public List<City> ListOfCities()
        {
            List<City> list = new List<City>();
            foreach (cities_zip city in Enum.GetValues(typeof(cities_zip)))
            {
                City newCity = new City();
                newCity.CityName = city.ToString();
                newCity.CityValue = (int)city;
                list.Add(newCity);
            }
                return list;
        }
    }    
    public class City
    {
        public string CityName { get; set; }
        public int CityValue { get; set; }
    }
    public enum cities_zip
    {
        Emsdetten = 48282,
        Berlin = 12345,
        Rheine = 48369,
    }
