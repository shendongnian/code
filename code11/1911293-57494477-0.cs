     public class Person {
     public int Id;
     public string Prename;
     public string Surname;
     public Gender Gender;
     public decimal Salary;
     }
     
     public class Employee  {
     public int Id;
     public string Prename;
     public string Surname;
     public Gender Gender;
     //remove attributes we don't need (It's here salary)
     }
     //in Your Function
     public function x{
            
      Person model = getPersonData();
      if(User.Roles.Contains('Employee')
      {
       return (Employee) model;
      }
     }
