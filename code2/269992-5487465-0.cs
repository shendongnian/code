    public class MyClass 
    {     
       public int Mandatory {get; set;}
       public int Optional {get; set;}
       public MyClass(int mandatory)
       {
          Mandatory = mandatory;
       }
       public MyClass(int mandatory, int optional)
       {
          Mandatory = mandatory;
          Optional = optional;
       }
    }
