    interface IModifiable<T>
    {
      void Add(T Info);
      void Delete(T item);
      T GetInfo(string name);
    }
    public class MyClass : IModifiable<List<string>>
    {
       public void Add(List<string> list)
       { 
          //do something
       }
    
       public void Delete(List<string> item)   {  }
       public List<string> GetInfo(string name)  {  }
    }
