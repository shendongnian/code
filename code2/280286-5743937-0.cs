    [Authorize]
    [HttpPost]
    public ActionResult Create([Bind(Exclude = "ImageData")]Customers saveCustomer, HttpPostedFileBase ImageData)
    {
        try
        {
            // TODO: Add insert logic here
            var upload = Request.Files["ImageData"];
            if (upload.ContentLength > 0)
            {
                string savedFileName = Path.Combine(
                      ConfigurationManager.AppSettings["FileUploadDirectory"],
                      "customers_" + saveCustomer.FirstName + "_" + saveCustomer.LastName + ".jpg");
                upload.SaveAs(savedFileName);
            }
            _db.Customers.InsertOnSubmit(saveCustomer);
            _db.SubmitChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    } 
