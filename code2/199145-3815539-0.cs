    [Serializable]
    public class Child
    {
        public string Foo { get; set; }
    
        public Parent Parent { get { return parent; } set { parent = value; } }
    
        // We don't want to serialize this property explicitly.
        // But we could set it during parent deserialization
        [NonSerialized]
        private Parent parent;
    }
    [Serializable]
    public class Parent
    {
        // BinaryFormatter or DataContractSerializer whould call this method
        // during deserialization
        [OnDeserialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            // Setting this as parent property for Child object
            Child.Parent = this;
        }
    
        public string Boo { get; set; }
    
        public Child Child { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Child c = new Child { Foo = "Foo" };
            Parent p = new Parent { Boo = "Boo", Child = c };
    
            using (var stream1 = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof (Parent));
                serializer.WriteObject(stream1, p);
                stream1.Position = 0;
                var p2 = (Parent)serializer.ReadObject(stream1);
           
                Console.WriteLine(object.ReferenceEquals(p, p2)); //return false
                Console.WriteLine(p2.Boo); //Prints "Boo"
                
                //Prints: Is Parent not null: True
                Console.WriteLine("Is Parent not null: {0}", p2.Child.Parent != null);
            }
        }
    
    }
