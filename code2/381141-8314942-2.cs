    public class Class1
    {
        public string Property1 { get; private set; }
        public string Property2 { get; set; }
        public DateTime AddedProperty { get; set; }
        public Class1()
        {
        }
        public Class1(string prop1, string prop2) : this()
        {
            Property1 = prop1;
            Property2 = prop2;
        }
        public Class1(Class1DTO dto)
        {
            Property1 = dto.Property1;
        }
        public Class1DTO CreateDTO()
        {
            return new Class1DTO 
            { 
                AddedProperty = AddedProperty,
                Property1 = Property1,
                Property2 = Property2
            };
        }
    }
    public class Class1DTO
    {
        public string Property1 { get; set; }
        public string Property2 { get; set; }
        public DateTime AddedProperty { get; set; }
    }
