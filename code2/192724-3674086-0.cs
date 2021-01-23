    [TestFixture]
    public class SO3672777
    {
        [Test]
        public void ShouldRoundTripUInt16Array()
        {
            ushort[] data = { 0, 1, 2, 3, 4, 5, 6 };
            TestData item = new TestData();
            item.Raw = data;
            TestData clone = Serializer.DeepClone(item);
            Assert.AreNotSame(item, clone);
            Assert.IsNotNull(clone.Raw);
            Assert.AreEqual(item.Raw.Length, clone.Raw.Length);
            for (int i = 0; i < item.Raw.Length; i++)
            {
                Assert.AreEqual(item.Raw[i], clone.Raw[i]);
            }
        }
        [ProtoContract]
        public class TestData
        {
            [ProtoMember(1)]
            public ushort[] Raw { get; set; }
        }
    }
