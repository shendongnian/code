    public class MyClass
    {
       public void MyMethod(string param1, int param2)
       {
           Condition.Requires(param1).IsNotNullOrWhiteSpace();
           Condition.Requires(param2).IsGreaterThan(0);
    
           ...
       }
    }
