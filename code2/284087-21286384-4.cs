    [SetUp]
    public void GeneralTestSetup()
    {
      // verify the iterated sources are not empty
      string testDescription = string.Format("The ordered list of objects must have at least 3 elements, but instead has only {0}.", mOrderedList.Count);
      Assert.IsTrue(2 < mOrderedList.Count, testDescription);
    }
