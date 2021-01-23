    // this method is called from several threads concurrently
    public void IncrementProperty()
    {
       using (var context = new MyEntities())
       {
          context.SomeObject.SomeIntProperty++;
          context.SaveChanges();
       }
    }
