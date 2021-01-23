    //ran in linqpad c# program mode, you'll need to provide an entry point.....
    void Main()
    {
    	IPerson x;
    	x = new Both(new Employee());
    	x.call(); //outputs "Emplyee"
    	x = new Both(new Customer());
    	x.call(); //outputs "Customer"
    }
    
    class Customer :  ICustomer
    {
    	public void call() {"Customer".Dump();}
    }
    class Employee :  IEmployee
    {
    	public void call() {"Employee".Dump();}
    }
    class Both : IPerson
    {
         private IPerson Person { get; set; }
         public Both(IPerson person)
         {
             this.Person = person;
         }
         public void call()
         {
         	Person.call();
         }
    } 
    interface IPerson { void call(); }  
    interface ICustomer : IPerson { } 
    interface IEmployee : IPerson { } 
