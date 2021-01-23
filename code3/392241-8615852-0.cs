    public class SomeClass: ISerializable
    {
       public double SomeValue {get;set;}
    
       public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("someValue", SomeValue * 10);
            }
       public SomeClass(SerializationInfo info, StreamingContext context)
       {
         this.SomeValue = info.GetDouble(someValue) / 10;
       } 
    }
