    // EF generated part
    public partial class EntityObject
    {
      protected string SpecialString { get; set; }
    }
    
    // Your part
    public partial class EntityObject
    {
      public MySpecialClass Special
      {
        get
        {
          return MySpecialClass.Deserialize(SpecialString);
        }
        set
        {
          SpecialString = MySpecialClass.Serialize(value);
        }
      }
    }
