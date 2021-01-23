    // this contract is an INVALID example
    [ProtoContract]
    [ProtoInclude(1, typeof(Employee))]
    public class Person{
        [ProtoMember(1)]
        public string Name { get; set; }
    }
