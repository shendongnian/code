          public class MyCustomClass
      {
        public string MyStrData {get;set;}
      }
    
      [DataContract]
      public class Data
      {
        [DataMember]
        public int mInt;
    
        [DataMember]
        public MyCustomClass MyCustonObj;
        
        public 
    
        [OnDeserialized]
        void OnDeserialized(StreamingContext c)
        {
          if(MyCustonObj == null)
          {
            MyCustonObj = new MyCustomClass();
            MyCustonObj.MyStrData ="Overridden in serialization";
          }
        }
    
        [OnDeserializing]
        void OnDeserializing(StreamingContext c)
        {
          if(MyCustonObj == null)
          {
            MyCustonObj = new MyCustomClass();
            MyCustonObj.MyStrData ="Overridden in  deserializing";
          }
        }
    
        [OnSerialized]
        void OnSerialized(StreamingContext c)
        {
          
        }
    
        [OnSerializing]
        void OnSerializing(StreamingContext c)
        {
          
        }
      }
