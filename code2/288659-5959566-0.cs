    public interface IPerson 
    {
     IPersonApp1 Person1 {get; set;}
     IPersonApp2 person2 {get; set;}
    }
    
    class Person : IPerson
    {
     IPerson1 Person1 {get; set;}
     IPerson2 Person2 {get; set;}
    }
----------
       public interface IPerson1
      {
        // App1 specific behavior here
         void App1SpecificMethod1();
      }
      class Person1: IPerson1
       {
         void App1SpecificMethod1()
          {
           // implementation
          }
       }
    class App1 
    {
       IPerson objPerson;
       // Dependency injection using framework
       App1(IPerson objPerson)
      {
        this.objPerson = objPerson;
        // Dependency injection using setter
        this.objPerson.Person1 = new Person1();
      }
    }
   
