    [Test]
       public void DivisorsTest_01()
       {   
           Integer n = 0; 
           IEnumerable<Integer> actual;
           actual = Science.Mathematics.NumberTheoryFunctions.Divisors(n);
           Assert.IsFalse(actual.Any()); // There should not be any elements returned so empty
       }
