    var myObject = JsonConvert.DeserializeObject<MyClass>(myJson);
    var myArray = myObject2.ToArray():
    public class MyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public int Phone { get; set; }
        public object[] ToArray()
        {
            return new object[]
            {
                Id,
                Name,
                Address,
                Country,
                Phone
            };
        }
    }
    
