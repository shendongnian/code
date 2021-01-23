      /// <summary>
      /// Validate the array is within a specified amount
      /// </summary>
      [Test]
      public void ValidateArrayWithinValue()
      {
         var array1 = new double[] { 0.0023d, 0.011d, 0.743d };
         var array2 = new double[] { 0.0033d, 0.012d, 0.742d };
         Assert.That(array1, Is.EqualTo(array2).Within(0.00101d), "Array Failed Constaint!");
      } // ValidateArrayWithinValue
