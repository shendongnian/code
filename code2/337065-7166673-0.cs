    class Employee
    {
      public virtual Employee Clone();
    };
    class Manager
    {
      public override Manager Clone()
      {
         return new Manager(this);
      }
    };
