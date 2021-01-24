    public ActionResult Index(int? Contract_Num)
    {
        if (Contract_Num != null)
        {
            var list = _context.ContractMonth.Where(x => x.contracts.Contract_Num == Contract_Num.Value).ToList();
            return View(list);
        }
        else
        {
            // return new empty list 
        }
    }
