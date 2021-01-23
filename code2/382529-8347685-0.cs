    public class EmployeeCollection<T> : IEnumerable<T>
    {
      List<T> empList = new List<T>();
   
      public void AddEmployee(T e)
      {
          empList.Add(e);
      }
 
      public T GetEmployee(int index)
      {
          return empList[index];
      }
 
      //Compile time Error
      public void PrintEmployeeData(int index)
      {
         Console.WriteLine(empList[index].EmployeeData);   
      }
 
      //foreach support
      IEnumerator<T> IEnumerable<T>.GetEnumerator()
      {
          return empList.GetEnumerator();
      }
 
      IEnumerator IEnumerable.GetEnumerator()
      {
          return empList.GetEnumerator();
      }
    }
 
    public class Employee
    {
      string FirstName;
      string LastName;
      int Age;
   
      public Employee(){}
      public Employee(string fName, string lName, int Age)
      {
        this.Age = Age;
        this.FirstName = fName;
        this.LastName = lName;
      }
 
      public string EmployeeData
      {
        get {return String.Format("{0} {1} is {2} years old", FirstName, LastName, Age); }
      }
    }
