     public class TestClass
        {
       private Guid _EventId;
       public Guid EventId { 
          get=> (_Eventid = 
              _Eventid==null ?  Guid.NewGuid() :
               _Eventid);
          set=>_EventId=value; 
             }
        
            public string prop1 { get; set; }
        
            public int prop2 { get; set; }
        }
