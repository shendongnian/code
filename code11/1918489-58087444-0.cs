    public void editBuyerByID(Buyer buyer)
    {
      using (var context = dc)
      {
        context.Entry(buyer).State = EntityState.Modified;
    	context.SaveChanges();
      }
    }
