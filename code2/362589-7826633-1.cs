    [ProtoContract]
    class Person {
        [ProtoMember(1)]
        public string Name {get;set:}
        [ProtoMember(2)]
        public int Id {get;set;}
        [ProtoMember(3)]
        public int Age {get;set;}
    }
