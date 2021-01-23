    public class Test : IEquatable<Test>
    {
      public int Id {get;set;}
      public bool Equals(Test other)
      {
        return this.Id == other.Id;
      }
    }
    
