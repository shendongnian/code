    [HttpPost]
    public async Task<JsonResult> SaveRegistration(string registration)
    {
    	var message = "";
    	var status = "";
    	try
    	{
    		var path = Path.Combine(_hostingEnvironment.WebRootPath, "Files\\Images");
    		if (!Directory.Exists(path))
    		{
    			Directory.CreateDirectory(path);
    		}
    		path += "\\";
    		if (!string.IsNullOrEmpty(registration))
    		{
    		
    			var reg = new Registration();
    			reg.Name = registration;
    			var file = Request.Form.Files[0];
    			if (file != null)
    			{
    				var fileName = file.FileName;
    				if (System.IO.File.Exists(path + fileName))
    				{
    					fileName = $"{DateTime.Now.ToString("ddMMyyyyHHmmssfff")}-{fileName}";
    				}
    				using (var fileStream = new FileStream(path + fileName, FileMode.Create))
    				{
    					await file.CopyToAsync(fileStream);
    				}
    				reg.Picture = fileName;
    			}
    			_context.Registration.Add(reg);
    			await _context.SaveChangesAsync();
    		
    			message = "Data is not saved";
    			status = "200";
    		}
    	}
    	catch (Exception ex)
    	{
    		message = ex.Message;
    		status = "500";
    	}
    	return Json(new
    	{
    		Message = message,
    		Status = status
    	});
    }
