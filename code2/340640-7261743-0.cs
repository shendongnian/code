    public class Customer
    {
        public int EmpID { get; set; }
        public string Name { get; set; }
    
        public List<Address> Address { get; set; }
    
        public double Salary { get; set; }
    }
    
    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PostCode { get; set; }
    }
    
    public class TestClass
    {
        public void Populate()
        {
            List<Customer> oCust = new List<Customer>()
                {
                        new Customer() { EmpID=1, Name="Sonia", Address = new List<Address>() 
                                            {
                                                new Address { Address1 = "Sonia addr 11", Address2 = "Sonia addr 12", PostCode = "111" },
                                                new Address { Address1 = "Sonia addr 21", Address2 = "Sonia addr 22", PostCode = "222" }
                                            } 
                                        },
                        new Customer() { EmpID=2, Name="Bill", Address = new List<Address>() 
                                            {
                                                new Address { Address1 = "Bill addr 11", Address2 = "Bill addr 12", PostCode = "111" },
                                                new Address { Address1 = "Bill addr 21", Address2 = "Bill addr 22", PostCode = "222" }
                                            } 
                                        },
                        new Customer() { EmpID=3, Name="Mark", Address = new List<Address>() 
                                            {
                                                new Address { Address1 = "Mark addr 11", Address2 = "Mark addr 12", PostCode = "111" },
                                                new Address { Address1 = "Mark addr 21", Address2 = "Mark addr 22", PostCode = "222" }
                                            } 
                                        }
                };
        }
    }
