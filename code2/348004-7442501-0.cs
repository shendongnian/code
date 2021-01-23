     [ProtoContract]
     public class Customer {
         [ProtoMember(1)]
         public List<Order> Orders {get {....}}
         [ProtoMember(2)]
         public string Name {get;set;}
         ... etc
     }
