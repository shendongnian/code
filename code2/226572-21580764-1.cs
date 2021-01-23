            [Test]
            public void GetIndexedType()
            {
                Assert.AreEqual(null, ((ICollection)null).GetIndexedType());
                Assert.AreEqual(typeof(int), (new List<int>()).GetIndexedType());
                Assert.AreEqual(typeof(bool), (new SortedList<string, bool>()).GetIndexedType());
            }
            [Test]
            public void GetEnumeratedType()
            {
                Assert.AreEqual(null, ((ICollection)null).GetEnumeratedType());
                Assert.AreEqual(typeof(int), (new List<int>()).GetEnumeratedType());
                Assert.AreEqual(typeof(KeyValuePair<string, bool>), (new SortedList<string, bool>()).GetEnumeratedType());
            }
