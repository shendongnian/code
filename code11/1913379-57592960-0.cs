    [HttpPost]
    [ActionName("BookingForm")]
    public ActionResult BookingFormPost(Booking model)
    {
        if (ModelState.IsValid)
        {
            db.Bookings.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
        var newModel = new School();
        newModel.RollNumber = model.RollNumber;
        newModel.Date = model.Date;
        string ValidateMsg = "Please complete all fields";
        newModel.ValidationMsg = ValidateMsg;
        return View("BookingForm", newModel);
    }
