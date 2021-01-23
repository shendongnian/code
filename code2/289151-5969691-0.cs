        public class InlineComparer<T> : IEqualityComparer<T>
        {
            private readonly Func<T, T, bool> getEquals;
            private readonly Func<T, int> getHashCode;
            public InlineComparer(Func<T, T, bool> equals, Func<T, int> hashCode)
            {
                getEquals = equals;
                getHashCode = hashCode;
            }
            public bool Equals(T x, T y)
            {
                return getEquals(x, y);
            }
            public int GetHashCode(T obj)
            {
                return getHashCode(obj);
            }
        }
        class TestClass
        {
            public string S { get; set; }
        }
        [TestMethod]
        public void testThis()
        {
            var l1 = new List<TestClass>()
                         {
                             new TestClass() {S = "one"},
                             new TestClass() {S = "two"},
                         };
            var l2 = new List<TestClass>()
                         {
                             new TestClass() {S = "three"},
                             new TestClass() {S = "two"},
                         };
            var dupComparer = new InlineComparer<TestClass>((i1, i2) => i1.S == i2.S, i => i.S.GetHashCode());
            var unionList = l1.Union(l2, dupComparer);
            Assert.AreEqual(3, unionList);
        }
