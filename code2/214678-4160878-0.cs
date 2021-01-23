    IEnumerable<DTOeduevent> newList = eduList;
    if (cla != null)
    {
      newList = newList.Where(s => s.EventClassID == cla);
    }
    if (loc != null)
    {
      newList = newList.Where(s => s.LocationID == loc);
    }
    if (edu != null)
    {
      newList = newList.Where(s => s.EducatorID == edu);
    }
    
    newList = newList.ToList();
