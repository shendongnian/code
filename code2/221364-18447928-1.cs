    public class Person : SomeBaseClass
    {
        public string Name1;
    
        public string Name2;
    
        [XmlIgnore]
        public string Name3;
    
        public Person()
        {
        }
    
        public Person(string first, string second, string third)
        {
            Name1 = first;
            Name2 = second;
            Name3 = third;
        }
    }
