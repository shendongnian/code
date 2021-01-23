    using(ISession session = partsDB.OpenSession())
    {
      using (var tx = session.BeginTransaction())
      {
        IList<Part> parts = 
          session
          .CreateQuery("select p from Part as p where p.PartTypeID <> 2")
          .List<Part>();
    
        foreach (Part part in parts)
        {
          Console.WriteLine("{0} - {1}", part.ID, part.Name);
    
          foreach (PartAssemblyItem subPart in part.PartAssemblyItems)
          {
            Console.WriteLine("--> {0} - {1}", subPart.Part.ID, subPart.Part.Name);
          }
        }
      }
    }
