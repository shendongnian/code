     static void Main(string[] args)
        {
            Employee e1 = new Employee() { EmpAge = 20, EmpId = 123, EmpName = "XYZ", EmpSex = "M" };
            Employee e2 = new Employee() { EmpAge = 20, EmpId = 123 , EmpName = "XYq", EmpSex = "M" };
            Person p1 = new Person() { Age = 20, name ="ABC"  };
            Person p2 = new Person() { Age = 20, name = "ABC" };
            Console.WriteLine("Employee Equality :" + IsObjectEquals(e1, e2).ToString());
            Console.WriteLine("Person Equality :" +IsObjectEquals(p1, p2).ToString());
            Console.ReadLine();
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
