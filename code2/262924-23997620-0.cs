    [DataContract]
    public class MyClass {
        [DataMember]
        public A MyProperty { get; set; }
    }
    [DataContract]
    [KnownType(typeof(B))]
    [KnownType(typeof(C))]
    public class A {
    
    }
    [DataContract]
    public class B : A {
    }
    [DataContract]
    public class C : A {
    }
