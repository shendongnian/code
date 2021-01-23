    [Test]
       public void DivisorsTest_03()
       {
           Integer n = 9;
           Integer[] expected = new Integer[3] { 1,3,9 };
           IEnumerable<Integer> actual;
           actual = Science.Mathematics.NumberTheoryFunctions.Divisors(n);
           var actual1 = actual.ToArray();
           Assert.AreEqual(expected[0], actual1[0]);
           Assert.AreEqual(expected[1], actual1[1]);
           Assert.AreEqual(expected[2], actual1[2]);
       }
