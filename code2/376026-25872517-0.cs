    public static class FooAssert
    {
         public static void CountEquals(int expected, FooConsumer consumer)
         {
             int actualCount = 0;
             while (consumer.ConsumeItem() != null)
                 actualCount++;
             NUnit.Framework.Assert.AreEqual(expected, actualCount);
         }
    }
