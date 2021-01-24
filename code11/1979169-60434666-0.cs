    public class Employee : IPerson
        {
            public int ID { get; set; }
    
            public string Name { get; set; }
        }
    
        public class Customer : IPerson
        {
            public int ID { get; set; }
    
            public string Name { get; set; }
        }
    
        public interface IPerson
        {
            int ID { get; set; }
    
            string Name { get; set; }
        }
        public class Test
        {
            public void MyTest()
            {
                List<Dictionary<string, IPerson>> listOfItems = new List<Dictionary<string, IPerson>>();
    
                Dictionary<string, IPerson> myEmployees = new Dictionary<string, IPerson>();
                string someString = "blah";
                Employee e = new Employee();
                e.Name = "Bob";
                e.ID = 1;
    
                myEmployees.Add(someString, e);
    
                Dictionary<string, IPerson> myCustomers = new Dictionary<string, IPerson>();
                string someOtherString = "blah";
                Customer c = new Customer();
                c.Name = "Robert";
                c.ID = 2;
    
                myCustomers.Add(someOtherString, c);
    
                listOfItems.Add(myEmployees);
                listOfItems.Add(myCustomers);
            }
        }
