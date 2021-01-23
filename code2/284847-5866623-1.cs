    public class Employee
    {
        public string ID { get; set; }
        public string Name { get; set; }
    
        public override string ToString()
        {
            return string.Format("ID = {0} Name = {1}", ID, Name);
        }
    }
    
    public class TestClass2
    {
        public TestClass2(Employee e)
        {
            e.ID="007";
            e.Name="james";
        }
    }  
  
    static void Main()
    {
    
        Employee e = new Employee();
        e.ID = "0";
        e.Name = "nobody";
        TestClass2 t = new TestClass2(e);
        Console.WriteLine(e); //Output ID = 007 Name = James 
    }  
           
