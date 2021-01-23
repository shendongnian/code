    using System.Runtime.Serialization;
    [DataContract] class Foo {
        public Foo() { Bar = this; }
        [DataMember] public Foo Bar { get; set; }
        static void Main() {
            new DataContractSerializer(typeof(Foo)).WriteObject(
                System.IO.Stream.Null, new Foo());
        }
    }
