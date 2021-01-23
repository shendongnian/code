    public class Country
    {
        public string Name { get; set; }
        public IList<City> Cities { get; set; }
        public Country(string _name)
        {
            Cities = new List<City>();
            Name = _name;
        }
    }
    
    List<Country> countries = new List<Country> { new Country("UK"), 
                                         new Country("Australia"), 
                                         new Country("France") };
    
    bindingSource1.DataSource = countries;
    
    comboBox1.DataSource = bindingSource1.DataSource;
    
    comboBox1.DisplayMember = "Name";
    comboBox1.ValueMember = "Name";
