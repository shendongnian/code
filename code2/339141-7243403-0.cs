    [ProtoContract]
    public class SomeWrapper {
         [ProtoMember(1, DynamicType = true)]
         public object Value {get;set;}
    }
