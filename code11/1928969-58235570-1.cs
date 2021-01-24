    public class Car
    {
        public string make { get; set; }
        public string model { get; set; }
        public int year { get; set; }
    }
    
    public class Person
    {
        public string name { get; set; }
        public int age { get; set; }
        public List<Car> cars { get; set; }
    }
    
    public class PersonResponse
    {
        public Person person { get; set; }
    }
