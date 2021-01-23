    [Authorize]
    [HttpPost]
    public ActionResult Create([Bind(Exclude = "ImageData")]Customers saveCustomer, HttpPostedFileBase ImageData)
    {
        try
        {
            // TODO: Add insert logic here
            var upload = Request.Files["ImageData"];
            string savedFileName = "";            
            if (upload.ContentLength > 0)
            {
                 savedFileName = Server.MapPath("/Resources/images/customers/" + "customer_" + saveCustomer.FirstName + "_" + saveCustomer.LastName + ".jpg"); 
                upload.SaveAs(savedFileName);
            }
            saveCustomer.ImageData = savedFileName;             
            _db.Customers.InsertOnSubmit(saveCustomer);
            _db.SubmitChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    } 
