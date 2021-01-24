    class ReturnObject
    {
        public List<Company> Companies { get; set; }
        public List<Animals> Animals { get; set; }
    }
    class Company
    {
        public string Name { get; set; }
        public decimal NetWorth { get; set; }
        public string Country { get; set; }
    }
    class Animals
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public float JumpHeight { get; set; }
    }
    public IHttpActionResult GetCompanyAnimals(object objectName) 
    {
        Animal animal = new Animal();
        Company company = new Company();
        ReturnObject obj = new ReturnObject();
        obj.Animals.Add(animal);
        obj.Companies.Add(company);
        return obj;
    };
