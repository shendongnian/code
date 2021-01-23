    [HttpPost, Authorize(Roles = "User"), ValidateAntiForgeryToken]
    public virtual ActionResult GetSignatories(string contractId, int version)
    {
        //NOTE Should be extracted
        var contract = _contractService.GetContract(contractId);
        if (contract == null) 
            return HttpNotFound();
        var result = _contractService.ValidateContract(contract);
        if (result == ValidationResult.Unauthorized) 
            return new HttpUnauthorizedResult();
        if (result == ValidationResult.NotFound) 
            return HttpNotFound();
        return Json(contract.CurrentVersion.Tokens.Select(x => x.User).ToList());
    }
