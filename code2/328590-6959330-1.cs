    public class Cars
    {
        public List<string[]> Companycars { get; set; }
        public List<string[]> Rentalcars { get; set; }
        public Cars()
        {
            Rentalcars = new List<string[]>();
            Companycars = new List<string[]>();
        }
    }
----------
    string myCars = "{\"companycars\":[[\"VIN\",\"LICENSEPLATE\"],[\"VIN\",\"LICENSEPLATE\"]],\"rentalcars\":[[\"VIN\",\"LICENSEPLATE\"],[\"VIN\",\"LICENSEPLATE\"]]}";
    Cars allCars = JsonConvert.DeserializeObject<Cars>(myCars);
