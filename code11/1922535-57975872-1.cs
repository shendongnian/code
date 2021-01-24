    IEnumerable<SomeObject> GetObjects()
    {
       if (m_SomeObjectCollection == null)
       {
          yield break;
       }
       foreach(SomeObject item in m_SomeObjectCollection)
       {
          yield return item;
       }
    
       foreach (var item in GetOtherObjects())
         yield return item;
    }
