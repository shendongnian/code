    [TestFixture]
    public class OrderingTests
    {
        public class TestObject : IEntity<int>
        {
            public int Id { get; set; }
        }
        [Test]
        public void Can_reorder_using_index_list()
        {
            IList<TestObject> list = new List<TestObject>
            {
                new TestObject { Id = 1 },
                new TestObject { Id = 2 },
                new TestObject { Id = 3 },
                new TestObject { Id = 4 },
                new TestObject { Id = 5 }
            };
            IList<int> indexList = new[] { 10, 5, 1, 9, 2, 4 };
            ArrayList.Adapter((IList)list)
                .Sort(new IndexComparer<TestObject, int>(x => list.IndexOf(x), indexList, list.Count));
            Assert.That(list[0].Id, Is.EqualTo(5));
            Assert.That(list[1].Id, Is.EqualTo(1));
            Assert.That(list[2].Id, Is.EqualTo(2));
            Assert.That(list[3].Id, Is.EqualTo(4));
            Assert.That(list[4].Id, Is.EqualTo(3));
        }
    }
