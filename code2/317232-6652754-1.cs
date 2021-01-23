    [HttpGet]
    public ActionResult LoanInformation(int id) 
    {
      var loanInfo = // get data by given id..
      var model = new LoadInformationModel {
        StudentCode = loanInfo.StudentCode,
        // etc
        Type = new List<Damage> { new Damage { Value = "Damaged"}, new Damage { Value = "Damaged Again" }
      }
     
      return View(model);
    }
