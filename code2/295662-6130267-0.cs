    public abstract class BaseClass<T>
    {
         public BaseClass<T>(string input)
         {
             DoSomething(input);
         }
         protected abstract void DoSomething(string input);
    }
