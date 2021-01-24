    [Serializable]
    public class Employee
    {
        public string Name;
        public string Job;
        public string ImageUrl;
    
        // RandomName will also have to be static
        public static List<Employee> GenrateEmployees(int noOfEmployees)
        {
            // Lists in c# grow dynamically bigger. 
            // It is more efficient to already set the final size
            var emp = new List<Employee>(i);
            for (int i = 0; i < noOfEmployees; i++)
            {     
                emp.Add(new Employee() 
                            { 
                                Name = RandomName(), 
                                Job = RandomName(),
                                imageUrl = "https://url/image/placeimg.jpg"
                            }
                        );
            }
            return emp;
        }
    }
