    public ActionResult Index(int id)
    {
        var contractMonth =_context.ContractMonth.FirstOrDefault(c => c.ContractId == id).contracts;  //<= contracts retrieve from Navigation Property
        return View(contractMonth);    
    }
