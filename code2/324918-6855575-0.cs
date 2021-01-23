     static void Main(string[] args)
        {
            List<Employee> ls1 = new List<Employee>();
            List<Employee> ls2 = new List<Employee>();
            Employee e1 = new Employee() { EmpAge = 20, EmpId = 123, EmpName = "XYZ", EmpSex = "M" };
            Employee e2 = new Employee() { EmpAge = 20, EmpId = 1232, EmpName = "XYZ", EmpSex = "M" };
            Console.WriteLine(IsObjectEquals(e1, e2).ToString());
        }
        public static bool IsObjectEquals(object obj1, object obj2)
        {
            
           PropertyInfo[] props1 = obj1.GetType().GetProperties();
           PropertyInfo[] props2 = obj2.GetType().GetProperties();
           
           foreach (PropertyInfo pinfo in props1)
           {
               var val1 = pinfo.GetValue(obj1, null);
               var val2 = pinfo.GetValue(obj2, null);
               if (val1.ToString().Trim() != val2.ToString().Trim())
               {
                        return false;
               }
                
           }
           return true;
        }
