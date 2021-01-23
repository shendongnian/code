    public class MonthlyPerformance
    {
        public List<Type> Type { get; set; }
    }
    
    public class Type
    {
        public int id { get; set; }
        public string countryId { get; set; }
        public string Name { get; set; }
    
        public List<Category> Category { get; set; }
    
        public Type()
        {
    
        }
    }
    
    public class Category
    {
        public int id { get; set; }
        public string countryId { get; set; }
        public string name { get; set; }
    
        public List<Fund> ConfigurationFund{ get; set; }
    
        public Category()
        {
    
        }
    }
    
    public class Fund
    {
        public int id { get; set; }
        public string countryId { get; set; }
        public string name { get; set; }
    
        public Fund()
        {
    
        }
    }
 
