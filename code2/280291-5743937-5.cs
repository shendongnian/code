    [Authorize]
    [HttpPost]
    public ActionResult Create([Bind(Exclude = "ImageData")]Customers saveCustomer, HttpPostedFileBase ImageData)
    {
        try
        {
            // TODO: Add insert logic here
            var upload = Request.Files["ImageData"];
            string savedFileName = "";  //string for saving the image server-side path          
            if (upload.ContentLength > 0)
            {
                 savedFileName = Server.MapPath("/Resources/images/customers/" + "customer_" + saveCustomer.FirstName + "_" + saveCustomer.LastName + ".jpg"); //get the server-side path for store image 
                upload.SaveAs(savedFileName); //*save the image to server-side 
            }
            var index = savedFileName.IndexOf(@"\Resources\");            
            saveCustomer.ImageData = savedFileName.Substring(index, savedFileName.Length - index); //set the string of image server-side path to add-object             
            _db.Customers.InsertOnSubmit(saveCustomer); // save all field to databae (includes image server-side path)
            _db.SubmitChanges();  // save database changes
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    } 
