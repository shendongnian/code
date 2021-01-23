    var temp = e; // local temporary variable, used below
    IEnumerable<Publication> eChildrens = 
      children.OfType<Publication>().Where(ep =>  
                                             ep.ParentID.Equals(temp.PublicationId)); 
 
    if (eChildrens.Count() > 0) 
    { 
      e.ChildPublication = eChildrens; 
    } 
