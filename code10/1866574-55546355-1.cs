      public ActionResult Index(int contractId)
      {
          var ContractMonth =_context.ContractMonth.Where(c => c.ContractId == contractId).Include(s => s.contracts).ToList();
          return View(ContractMonth);
        }
