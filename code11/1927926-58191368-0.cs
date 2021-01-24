    public static class CAssert
    {
        public static void That(Action action, MyTestSuit suit)
        {
            try
            {
                action();
                if(suit.ShouldThrow)
                {
                    Assert.Fail("Not thrown any exception but expected to.")
                }
            }
            catch(Exception e)
            {
                if(suit.ShouldNotThrow)
                {
                    Assert.Fail("Exception was thrown but not expected.")
                }
            }
        }
    }
