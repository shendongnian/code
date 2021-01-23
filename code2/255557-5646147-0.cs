    var model = new ContractViewModel()
    {
       Contract = contractRepository.GetContract(id),
       Sows = db.Sows.ToList() // ToList() is important here to ensure the data is pulled into the Model
    }
    // Do any other initializations here
    ViewData.Model = model;
    return View();
