    IEnumerable<SomeObject> GetObjects()
    {
       if (m_SomeObjectCollection == null)
       {
          yield break;
       }
       foreach(SomeObject object in m_SomeObjectCollection)
       {
          yield return object;
       }
    
       foreach (var item in GetOtherObjects())
         yield return item;
    }
