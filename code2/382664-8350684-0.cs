    foreach (var e in europe) 
    { 
      // .Net 4.0 use: string.IsNullOrWhiteSpace()
      if (!string.IsNullOrEmpty(e.HadChild)
             // I prefer IndexOf which allows Culture and IgnoreCase 
          && e.HasChild.IndexOf("True", StringComparison.CurrentCultureIgnoreCase))
      { 
        IEnumerable<Publication> eChildrens = 
          children.OfType<Publication>()
                  .Where(ep => ep.ParentID.Equals(e.PublicationId))
                  .ToList();  //Force the IEnumeration to Enumerate.
 
        if (eChildrens.Count() > 0) 
        { 
          e.ChildPublication = eChildrens; 
        } 
      } 
    }    
