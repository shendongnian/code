    class Box
    {
      int ChildrenCount;
      Box GetChild (int index){/* some implementation*/}
      public IEnumerable<Box> Children
      {
        get
        {
          for(int i = 0; i != ChildrenCount; ++i)
            yield return GetChild(i);
        }
      }
      public IEnumerable<Box> Descendants
      {
        get
        {
          foreach(Box child in Children)
          {
            yield return child;
            foreach(Box desc in child.Descendants)
              yield return desc;
          }
        }
      }
    }
