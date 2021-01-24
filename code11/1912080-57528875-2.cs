    class ReturnObject
    {
        public List<Company> companies { get; set; }
        public List<Animals> animals { get; set; }
    }
    class Company
    {
        public string name { get; set; }
        public decimal netWorth { get; set; }
        public string country { get; set; }
    }
    class Animals
    {
        public string name { get; set; }
        public string species { get; set; }
        public float jumpHeight { get; set; }
    }
    public IHttpActionResult getCompanyAnimals(object objectName) 
    {
        Animal animal = new Animal();
        Company company = new Company();
        ReturnObject obj = new ReturnObject();
        obj.animals.add(animal);
        obj.companies.add(company);
        return obj;
    };
