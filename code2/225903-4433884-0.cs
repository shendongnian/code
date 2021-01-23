       [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mapper.CreateMap<HasByte, HasBool>();
            var hasByte = new HasByte() { Value = 1 };
            var hasBool = Mapper.Map<HasByte, HasBool>(hasByte);
        }
    }
    public class HasByte
    {
        public Nullable<Byte> Value { get; set; }
    }
    public class HasBool
    {
        public Nullable<bool> Value { get; set; }
    }
