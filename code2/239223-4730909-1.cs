    class SomePropertyBag{
    
    private Dictionary<string, MyClass> dict;
    
    T GetValue<T>(string name, T default)
    {
      MyClass res;
      if(!dict.TryGetValue(out res))
      {
         res = new MyClass<T>(name);
         dict.Add(name, res);
      }
      return ((MyClass<T>)res).GetValue();
    }
