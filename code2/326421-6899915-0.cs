    using System.Collections.Generic;
    using ProtoBuf;
    [ProtoContract]
    class MySpecialCollectionList<T>
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        private readonly List<MySpecialCollection<T>> items = new List<MySpecialCollection<T>>();
        [ProtoMember(2)]
        public List<MySpecialCollection<T>> Items { get { return items; } }
    }
    [ProtoContract]
    class MySpecialCollection<T>
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        private readonly List<Special<T>> items = new List<Special<T>>();
        [ProtoMember(2)]
        public List<Special<T>> Items { get { return items; } }
    }
    [ProtoContract]
    class Special<T>
    {
        [ProtoMember(1)]
        public string Name { get; set; }
        [ProtoMember(2)]
        public string Description { get; set; }
        [ProtoMember(3)]
        private readonly T _source;
        T Source { get { return _source; } }
        private Special()
        {
        }
        public Special(T source)
        {
            _source = source;
        }
    }
    [ProtoContract]
    [ProtoInclude(2, typeof(Ant))]
    [ProtoInclude(3, typeof(Cat))]
    [ProtoInclude(4, typeof(Dog))]
    interface IBeast
    {
        [ProtoMember(1)]
        string Name { get; set; }
    }
    [ProtoContract]
    class Ant : IBeast
    {
        public string Name { get; set; }
    }
    [ProtoContract]
    class Cat : IBeast
    {
        public string Name { get; set; }
    }
    [ProtoContract]
    class Dog : IBeast
    {
        public string Name { get; set; }
    }
    public static class Form1
    {
        private static void Main()
        {
            MySpecialCollectionList<IBeast> collectionList = GetSpecialCollectionList();
            var copy = Serializer.DeepClone(collectionList);
        }
        private static MySpecialCollectionList<IBeast> GetSpecialCollectionList()
        {
            var ant = new Ant() { Name = "Mr Ant" };
            var cat = new Cat() { Name = "Mr Cat" };
            var dog = new Dog() { Name = "Mr Dog" };
            var Special = new Special<IBeast>(ant);
            var specialCollection1 = new MySpecialCollection<IBeast>() {Items =
                {new Special<IBeast>(ant),
                new Special<IBeast>(cat),
                new Special<IBeast>(dog)}
            };
            specialCollection1.Name = "Special Collection1";
            var specialCollection2 = new MySpecialCollection<IBeast>()
            {
                Items =
                {new Special<IBeast>(ant),
                new Special<IBeast>(dog)}
            };
            specialCollection2.Name = "Special Collection2";
            var specialCollectionList = new MySpecialCollectionList<IBeast>()
            {
                Items ={
                specialCollection1, specialCollection2 }
            };
            specialCollectionList.Name = "Special Collection List";
            return specialCollectionList;
        }
    }
