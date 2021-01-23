    [TestMethod]
    public void TestDictionary()
    {
        var dictionary1 = new Dictionary<int, int>();
        var dictionary2 = new Dictionary<int, int>();
        for(int i = 0; i < 10; i++){
            dictionary1[i] = i;
            if (i != 3)
                dictionary2[i] = i;
        }
        dictionary1.Remove(3);
        dictionary1[3] = 3;
        dictionary2[3] = 3;
        CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, dictionary1.Values);
        CollectionAssert.AreEqual(new[] { 0, 1, 2, 4, 5, 6, 7, 8, 9, 3 }, dictionary2.Values);
    }
