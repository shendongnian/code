        public class Test
        {
            Dictionary<string, object> listOfItems = new Dictionary<string, object>();
            List<Employee> employees = new List<Employee>();
            List<customer> customers = new List<customer>();
            public Dictionary<string, object> getEmployees()
            {
                return employees.GroupBy(x => x.name, y => (object)y).ToDictionary(x => x.Key, y => y.FirstOrDefault());
                
            }//This method returns a dictionary of string as a key and Employee as a value.
            public Dictionary<string, object> getCustomers()
            {
                return customers.GroupBy(x => x.name, y => (object)y).ToDictionary(x => x.Key, y => y.FirstOrDefault());
            } //same principal 
            public Dictionary<string, object> getDifferentItems()
            {
                listOfItems = getEmployees();
                listOfItems.Concat(getCustomers());
                return listOfItems;
            }
        }
        public class Employee
        {
            public string name { get;set;}
        }
        public class customer
        {
            public string name { get;set;}
        }
