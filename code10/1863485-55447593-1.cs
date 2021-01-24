    public ActionResult Index(int? Contract_Num)
    {
        if (Contract_Num != null)
        {
            var list = (from cm in _context.ContractMonth
                        join ct in _context.Contracts
                        on cm.Contract_Num equals ct.Contract_Num
                        where cm.Contract_Num == Contract_Num.Value
                        select cm).ToList();
            return View(list);
        }
        else
        {
            // return new empty list 
        }
    }
