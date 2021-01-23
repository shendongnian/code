    [XmlRoot("customer")]
    public class CustomerData
    {
        // Must have a parameterless public constructor
        public CustomerData()
        {
        }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("city")]
        public string City { get; set; }
        [XmlElement("street")]
        public string Company { get; set; }
        public override string ToString()
        {
            return
                "Name=[" + this.Name + "] " +
                "City=[" + this.City + "] " +
                "Company=[" + this.Company + "]";
        }
    }
