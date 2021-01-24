    [HttpGet]
    public ActionResult GetOpenCATransaction()
    {
        using (var context = new dbavlincacctgEntities())
        {
            catransList = context.CATransactions.ToList();                
        }
        return PartialView("_CATransaction", catransList);
    }
