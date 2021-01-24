    public ActionResult Index(int id)
    {
        var contractMonth = _context.ContractMonth.Where(c => c.ContractsId == id).Include(s => s.contracts).ToList();
        return View(contractMonth);    
    }
