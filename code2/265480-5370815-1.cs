    interface IMy 
    {
      int GetFoo(string name, string foo, string bar);
    }
    
    static class MyExtensions
    {
        int GetFoo(this IMy my, string name)
        {
           return my.GetFoo(name, DefaultFoo, DefaultBar);
        }
    }
