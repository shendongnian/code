    public void WCFMethod()
    {
      using (DBContext db = new DBContext())
      {
        BusinessLogic logic = new BusinessLogic(db);
        logic.DoWork();
      }
    }
