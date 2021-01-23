    private static bool isValid(params Action[] actions)
    {
      for (int i = 1; i < actions.Length; i++)
        if (actions[i-1].TimeStamp >= actions[i].TimeStamp)
          return false;
      return true;
    }
    
    Assert.IsTrue(isValid(a1,a2,...,an));
