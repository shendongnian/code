    [DataContract]
    public class TestClass
    {
        // You can use List<T> or other generic collection
        [DataMember]
        public HashSet<int> h { get; set; }
        [DataMember]
        public TimeSpan t { get; set; }
        public TestClass()
        {
            h = new HashSet<int>{1,2,3,4};
            t = TimeSpan.FromDays(1);
        }
    }
----------
            var o = new TestClass();
            ms = new MemoryStream();
            var sr = new DataContractSerializer(typeof(TestClass));
            sr.WriteObject(ms, o);
            File.WriteAllBytes("test.xml", ms.ToArray());
            ms = new MemoryStream(File.ReadAllBytes("test.xml"));
            sr = new DataContractSerializer(typeof(TestClass));
            var readObject = (TestClass)sr.ReadObject(ms);
