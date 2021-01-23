    [TestClass]
    public class TestOrderedList
    {
        [TestMethod]
        public void TestIntegerList()
        {
            var startList = new List<int>(new int[] { 5, 2, 1, 4, 5, 5, 2 });
            var olist = new OrderedList<int>(startList);
            startList = startList.OrderBy(l=>l).ToList();
            CollectionAssert.AreEqual(startList, olist);
            Assert.AreEqual(0, olist.Add(0));
            int nextInc = olist.Max() + 1;
            Assert.AreEqual(olist.Count, olist.Add(nextInc));
            CollectionAssert.AreEqual(startList.Concat(new int[] {0,nextInc}).OrderBy(l=>l).ToList(), olist);
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
            int[] seed = new int[] {-2,-2};
            olist.AddRange(seed);
            CollectionAssert.AreEqual(seed, olist);
            olist.AddRange(new int[] { });
            olist.AddRange(new int[] { -2 });
            CollectionAssert.AreEqual(seed.Concat(new int[] { -2 }).ToList(), olist);
            olist.AddRange(new int[] { -3 });
            CollectionAssert.AreEqual((new int[] { -3,-2 }).Concat(seed).ToList(), olist);
        }
    } 
