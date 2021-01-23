    public void DoSomething<T>(List<T> object) where T : ....
    {
     //do what you want here
    }
    
    public void CallIt(Type t, object o) //o is List<Foo>
    {
     this.GetType().GetMethod("DoSomething").MakeGenericMethod(t).Invoke(o);
    }
