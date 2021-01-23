    public IList<StockCategory> GetAllStockCategories()
    {
        using (leDataContext db = new leDataContext())
        {
            return db.StockCategories.ToList();
        }
    }
