    [HttpPost]
    public ActionResult GetDocument(HttpPostedFileBase file)
    {
    	// Verify that the user selected a file
    	if (file != null && file.ContentLength > 0)
    	{
    		// Get file info
    		var fileName = Path.GetFileName(file.FileName);
    		var contentLength = file.ContentLength;
    		var contentType = file.ContentType;
    		
    		// Get file data
    		byte[] data = new byte[] { };
    		using (var binaryReader = new BinaryReader(file.InputStream))
    		{
    			data = binaryReader.ReadBytes(file.ContentLength);
    		}
    
    		// Save to database
    		Document doc = new Document()
    		{
    			FileName = fileName,
    			Data = data,
    			ContentType = contentType,
    			ContentLength = contentLength,
    		};
    		dataLayer.SaveDocument(doc);
    
    		// Show success ...
    		return RedirectToAction("Index");
    	}
    	else
    	{
    		// Show error ...
    		return View("Foo");
    	}
    }
