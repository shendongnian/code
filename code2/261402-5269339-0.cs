    public ActionResult Update(int id) {
        var service = new ServiceClass();
        var record = service.LoadModel(id);
        if (!TryUpdateModel(record)) {
            // There was an error binding data
            return View();
        }
        // Everything was ok, now save the record back to the database
        service.SaveModel(record);
        return View("Success");
    }
