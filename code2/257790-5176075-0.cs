    class AB {
      public A PartA;
      public B PartB;
      // Constructor
    };
    
    public void ManyJoin (List<A> colA, List<B> colB)
    {
      List<AB> innerJoin = new List<AB>();
      List<A> leftJoin = new List<A>();
      List<B> rightJoin = new List<B>();
      bool[] foundB = new bool[colB.Count];
    
      foreach (A itemA in colA)
      {
        int i = colB.FindIndex(itemB => itemB.ID == itemA.ID);
        if (i >= 0)
        {
          innerJoin.Add (new AB(itemA, colB[i]));
          foundB[i] = true;
        }
        else
          leftJoin.Add(itemA);
      }
    
      for (int j = 0; j < foundB.count; j++)
      {
        if (!foundB[j])
          rightJoin.Add(colB[j]);
      }
    }
