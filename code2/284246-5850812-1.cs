    [HttpPost]
    public ActionResult Pay(PayViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        PaymentGateway.Pay(model.CCNumber, model.ExpirationDate);
        return RedirectToAction("Success");
    }
