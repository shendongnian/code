    [Test]
    public void TestEnumerableEx()
    {
        List<int> list = null;
        Assert.IsTrue(list.IsNullOrEmpty());
        list = new List<int>();
        Assert.IsTrue(list.IsNullOrEmpty());
        list.AddRange(new []{1, 2, 3});
        Assert.IsFalse(list.IsNullOrEmpty());
        var enumerator = list.GetEnumerator();
        for(var i = 1; i <= list.Count; i++)
        {
            Assert.IsFalse(list.IsNullOrEmpty());
            Assert.IsTrue(enumerator.MoveNext());
            Assert.AreEqual(i, enumerator.Current);
		}
        Assert.IsFalse(list.IsNullOrEmpty());
        Assert.IsFalse(enumerator.MoveNext());
    }
	
