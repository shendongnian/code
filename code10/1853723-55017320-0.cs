    public class Reason
    {
      public int Id { get; set; }
      public string Reson { get; set; }
      public List<Reason> SecReason { get; set; }
      public int? PrimaryId { get; set; }
      //Adds child to this reason object or any of its children/grandchildren/... identified by primaryId
      public bool addChild(int primaryId, Reason newChildNode)
      {
        if (Id.Equals(primaryId))
        {
          addChild(newChildNode);
          return true;
        }
        else
        {
          if (SecReason != null)
          {
            foreach (Reason child in SecReason)
            {
              if (child.addChild(primaryId, newChildNode))
                return true;
            }
          }
        }
        return false;
      }
      public void addChild(Reason child)
      {
        if (SecReason == null) SecReason = new List<Reason>();
        SecReason.Add(child);
      }
    }
    private List<Reason> GetReasonsHierarchy(List<Reason> reasons)
    {
      List<Reason> reasonsHierarchy = new List<Reason>();
      foreach (Reason r in reasons)
      {
        bool parentFound = false;
        if (r.PrimaryId != null)
        {
          foreach (Reason parent in reasonsHierarchy)
          {
            parentFound = parent.addChild(r.PrimaryId.Value, r);
            if (parentFound) break;
          }
        }
        if (!parentFound) reasonsHierarchy.Add(r);
      }
      return reasonsHierarchy;
    }
