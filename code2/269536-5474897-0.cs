    [Serializable]
    public class B_Class
    {
      [NonSerialized]
      private A_Class a;  // backing field for your property, which can have the NonSerialized attribute.
      public int ID { get; set; }
    
      public A_Class A // property, which now doesn't need the NonSerialized attribute.
      {
        get { return a;}
        set { a= value; }
      }
    }
