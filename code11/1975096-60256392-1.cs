    public class Manufacturer
        {
            public string Name { get; set; }
            public string HeadQuarters { get; set; }
            public List<Model> Models { get; set; }
        }
    
        public class Model
        {
            public string Name { get; set; }
            public string Price { get; set; }
            public bool IsNew { get; set; }
            public List<Variant> Variants { get; set; }
        }
    
        public class Variant
        {
            public string Name { get; set; }
            public string FuelType { get; set; }
        }
