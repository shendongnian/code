    [Test]
       public void DivisorsTest_03()
       {
           Integer n = 9;
           Integer[] excepected = new Integer[3] { 1,3,9 };
           IEnumerable<Integer> actual;
           actual = Science.Mathematics.NumberTheoryFunctions.Divisors(n);
           var actual1 = actual.ToArray();
           Assert.AreEqual(excepected[0], actual1[0]);
           Assert.AreEqual(excepected[1], actual1[1]);
           Assert.AreEqual(excepected[2], actual1[2]);
       }
