    [TestClass]
    public class TestOrderedList
    {
        [TestMethod]
        public void TestIntegerList()
        {
            var startList = new List<int>(new int[] { 5, 2, 1, 4, 5, 5, 2 });
            var olist = new OrderedList<int>(startList);
            startList = startList.OrderBy(l => l).ToList();
            CollectionAssert.AreEqual(startList, olist);
            Assert.AreEqual(0, olist.Add(0));
            int nextInc = olist.Max() + 1;
            Assert.AreEqual(olist.Count, olist.Add(nextInc));
            CollectionAssert.AreEqual(startList.Concat(new int[] { 0, nextInc }).OrderBy(l => l).ToList(), olist);
            Assert.IsTrue(olist.Remove(0));
            Assert.IsFalse(olist.Remove(0));
            Assert.IsTrue(olist.Remove(nextInc));
            CollectionAssert.AreEqual(startList, olist);
            var addList = new List<int>(new int[] { 5, -1, 2, 2, -1, 3, 2 });
            olist.AddRange(addList);
            addList = startList.Concat(addList).OrderBy(l => l).ToList();
            CollectionAssert.AreEqual(addList, olist);
            olist.Remove(-1);
            addList.Remove(-1);
            CollectionAssert.AreEqual(addList, olist);
            olist.Remove(2);
            addList.Remove(2);
            CollectionAssert.AreEqual(addList, olist);
            olist = new OrderedList<int>();
            int[] seed = new int[] { -2, -2 };
            olist.AddRange(seed);
            CollectionAssert.AreEqual(seed, olist);
            olist.AddRange(new int[] { });
            olist.AddRange(new int[] { -2 });
            CollectionAssert.AreEqual(seed.Concat(new int[] { -2 }).ToList(), olist);
            olist.AddRange(new int[] { -3 });
            CollectionAssert.AreEqual((new int[] { -3, -2 }).Concat(seed).ToList(), olist);
        }
        [TestMethod]
        public void TestIndexOf()
        {
            var test = new OrderedList<int>(new[] { 0, -1, -2 });
            Assert.AreEqual(0, test.IndexOf(-2));
            Assert.AreEqual(2, test.IndexOf(0));
            test.Add(-2);
            Assert.AreEqual(0, test.IndexOf(-2));
            Assert.AreEqual(1, test.LastIndexOf(-2));
            test.Add(0);
            Assert.AreEqual(3, test.IndexOf(0));
            Assert.AreEqual(4, test.LastIndexOf(0));
        }
        [TestMethod]
        public void TestRangeFinding()
        {
            var test = new OrderedList<int> { 2 };
            CollectionAssert.AreEqual(new[] { 2 }, test.WithinRange(0, 6));
            CollectionAssert.AreEqual(new[] { 2 }, test.WithinRange(0, 2));
            CollectionAssert.AreEqual(new[] { 2 }, test.WithinRange(2, 4));
            CollectionAssert.AreEqual(new int[0], test.WithinRange(-6, 0));
            CollectionAssert.AreEqual(new int[0], test.WithinRange(6, 8));
            test = new OrderedList<int>();
            CollectionAssert.AreEqual(new int[0], test.WithinRange(6, 8));
            test = new OrderedList<int>{ -4, -2, 0 ,4, 6, 6 };
            CollectionAssert.AreEqual(new[] { 0, 4 }, test.WithinRange(0, 4));
            CollectionAssert.AreEqual(new[] { 0, 4 }, test.WithinRange(-1, 5));
            CollectionAssert.AreEqual(new[] { 6, 6 }, test.WithinRange(6, 8));
            CollectionAssert.AreEqual(new[] { 6, 6 }, test.WithinRange(5, 8));
            CollectionAssert.AreEqual(new[] { -4, -2 }, test.WithinRange(-5, -1));
            CollectionAssert.AreEqual(new[] { -4, }, test.WithinRange(-4, -3));
            CollectionAssert.AreEqual(new int[0], test.WithinRange(-6, -5));
            Assert.ThrowsException<ArgumentException>(() => test.WithinRange(6, 4));
        }
    }
