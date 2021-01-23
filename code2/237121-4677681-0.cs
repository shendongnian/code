    [Test]
    public void MultipleAssertSample()
    {
       Assert.Multiple(() =>
       {
          Assert.Fail("Boum!");
          Assert.Fail("Paf!");
          Assert.Fail("Crash!");
       });
    }
