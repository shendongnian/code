    public ActionResult Details(int S)
    {
        SLMEntitiesDB dbContext = new SLMEntitiesDB();
        var VL = (from U in dbContext.Users
              join P in dbContext.Products
              on U.PID equals P.PID
              where P.PID == U.PID
              select new UP(){
                  UserO = U,
                  ProductO = P
              }).Where(U => U.LID == S).ToList();
        return View(VL);
    }
