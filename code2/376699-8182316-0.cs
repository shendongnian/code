    [ProtoContract]
    class Wrapper
    {
        [ProtoMember(1)]
        public ILesson5TestInteface1 Content { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            Wrapper obj = new Wrapper
            {
                Content = new Lesson5TestClass2()
            }, clone;
            using(var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, obj);
                ms.Position = 0;
                clone = Serializer.Deserialize<Wrapper>(ms);
            }
            // here clone.Content *is* a Lesson5TestClass2 instance
        }
    }
