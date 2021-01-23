    class Employee
    {
       public int EmployeeID {get;set;}
       public DateTime Date {get;set;}
       public int PayID {get;set;}
    }
    
    class MyDictionary
    {
        private static Dictionary<int, List<Employee>> dict = new Dictionary<int, List<Employee>>();
        public static void Add(Employee obj)
        {
            if (dict.ContainsKey(obj.EmployeeID))
            {
                dict[obj.EmployeeID].Add(obj);
            }
            else
            {
                dict.Add(obj.EmployeeID, new List<Employee>() {obj });
            }
        }
        public static List<Employee> GetEmps(int key)
        {
            if (dict.ContainsKey(key))
                return dict[key];
            return null;
        }
    } 
