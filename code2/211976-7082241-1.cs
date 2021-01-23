    public class MyObject : ICloneable
    {
      public MyObject Clone()
      {
        // my cloning logic;  
      }
    
      object ICloneable.Clone()
      {
        return this.Clone();
      }
    }
