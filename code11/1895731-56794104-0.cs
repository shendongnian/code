    public class ClassA <T>
    {
        public T Name;
    }
    
    [Serializable]
    public class SerializeableClassA : ClassA<MyEnum> { }
    
    [Serializable]
    public class ClassB
    {
        public int num;
        public SerializeableClassA classA;
    }
