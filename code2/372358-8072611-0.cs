    public class MyList:List<Foo>
    {
       public Foo this[string name]
       {
          get { return this.FirstOrDefault(f=>f.Name == "Foo Name"); }
       }
    }
