    [Test]
    public void TestCompare_XtoY_GreaterThan()
    {
      int numObjects = mOrderedList.Count;
      for (int i = 1; i < numObjects; ++i)
      {
        for (int j = 0; j < i; ++j)
        {
          string testDescription = string.Format("{0} is greater than {1} which implies\n  {2}\n    is greater than\n  {3}"
                                                , i, j
                                                , mOrderedList[i], mOrderedList[j]
                                                );
          Assert.IsTrue(0 < mOrderedList[i].CompareTo(mOrderedList[j]), testDescription);
          Assert.IsTrue(0 < mOrderedList[i].Compare(mOrderedList[i], mOrderedList[j]), testDescription);
          Assert.IsTrue(0 < mOrderedList[j].Compare(mOrderedList[i], mOrderedList[j]), testDescription);
          Assert.Greater(mOrderedList[i], mOrderedList[j], testDescription);
        }
      }
    }
