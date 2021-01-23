        [ComplexType]
        public class Address
        {
            public string Country { get; set; }
            public string City { get; set; }
        }
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Address Address { get; set; }
        }
    ... then, if `myEntity` is a `Person`, `CurrentValues.PropertyNames` would contain "**Id**", "**Name**" and "**Address**" but not "**Address.Country**" or "**Address.City**" (nor "**Country**" or "**City**").
