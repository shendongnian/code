    public static void Main(string[] args)
    {
      List<ObjectA> listA = new List<ObjectA>()
      {
        new ObjectA(){Item = "abc" },
        new ObjectA(){Item = "ab" },
      };
      List<ObjectB> listB = new List<ObjectB>()
      {
        new ObjectB(){Item = "abc" },
      };
      // loop backwards removing entry if it is found in the other list
      for (int i = listA.Count - 1; i >= 0; i--)
        if (listB.Find(e => e.Item == listA[i].Item) != null)
          listA.RemoveAt(i);
    }
