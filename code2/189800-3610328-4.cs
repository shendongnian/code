    public class Derived : Base
    {
      public new string Name 
      {
        get { return base.Name; }
        set { base.Name = value; }
      }
      public Derived(string name) : base(name)
      { }         
    }
