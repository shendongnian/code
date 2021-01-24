    [![class Program
        {
            static void Main(string\[\] args)
            {
                var customer = new Customer() { CustomerID = 666, CustomerName = "john", IDNumber = "john123", MobilePhone = "9834567899", Address = "Test address 1" };
    
                //For user 1
                var allewdProperties = new string\[\] { "CustomerName", "IDNumber", "CustomerID" };//For user 1
    
    
                var json = JsonConvert.SerializeObject(customer
                                ,
                                new JsonSerializerSettings() { ContractResolver = new CustomContractResolver(allewdProperties.ToList()) }
                            );
    
                //Data for user1
                Console.WriteLine("Data for user 1");
                Console.WriteLine(json);
    
                //for user 2
                allewdProperties = new string\[\] { "MobilePhone", "Address" };//For user 2
                json = JsonConvert.SerializeObject(customer,
                    new JsonSerializerSettings() { ContractResolver = new CustomContractResolver(allewdProperties.ToList()) }
                );
                Console.WriteLine("Data for user 2");
                Console.WriteLine(json);
    
                Console.ReadLine();
            }
        }
    
        public class Customer
        {
            public int CustomerID { set; get; }
            public string CustomerName { set; get; }
            public string IDNumber { set; get; }
            public string MobilePhone { set; get; }
            public string Address { set; get; }
        }
    
        public class CustomContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
        {
            IEnumerable<string> _allowedProps = null;
    
            public CustomContractResolver(IEnumerable<string> allowedProps)
            {
                _allowedProps = allowedProps;
            }
    
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                return _allowedProps.Select(p => new JsonProperty()
                {
                    PropertyName = p,
                    PropertyType = type.GetProperty(p).PropertyType,
                    Readable = true,
                    Writable = true,
                    ValueProvider = base.CreateMemberValueProvider(type.GetMember(p).First())
                }).ToList();
            }
        }][1]][1]
