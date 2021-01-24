    public class Example
     {
        // As an example, you'd load the values from excel into this list of strings (using a function) 
        public List<string> ListFromExcel = new List<string>()
        {
            "Bob", "Frank", "Henry",
            "Sally", "Julia"
        };
        // We can make a list (collection) of virtually anything. I've created a list of the employee object (class): 
        public List<Employee> employees = new List<Employee>();
        public void CreateListOfEmployees()
        {
            // looping through each entry (string) in the ListFromExcel list: 
            foreach(string nameFromExcel in ListFromExcel)
            {
                // This is where I'm instantiating a new class with one paramater 
                employees.Add(new Employee(nameFromExcel));
            }
            // Just to demonstrate - I will output each item to the console 
            foreach (Employee person in employees)
            {
                Console.WriteLine(person.FirstName + " was added on " + person.addedDate); 
            }
        }
    }
