    public List<Item> GetDate(int page, int size = 50)
		{
		try
		{
		  using (var context = new ccoFinalEntities())
		  {
			return context.sales.Where(p => true == p.status && myID == p.id)
                                .Skip(page * size).Take(size).ToList();
		  }
		}
		catch
		{
		  return null;
		}
    }
