    public ActionResult AddRelease(ApplicationReleaseViewModel appRelease, HttpPostedFileBase deploymentPackage)
    		{
    			if (ModelState.IsValid)
    			{
    				ApplicationRelease dto = new ApplicationRelease();
    				appRelease.UpdateDto(dto);
    
    				using (StreamReader sr = new StreamReader(deploymentPackage.InputStream))
    				{
    					dto.DeploymentPackage = new byte[deploymentPackage.InputStream.Length];
    					deploymentPackage.InputStream.Read(dto.DeploymentPackage, 0, dto.DeploymentPackage.Length);
    				}
    
    				this.ApplicationService.AddApplicationRelease(dto);
    
    				return RedirectToAction("Index", new { ActionPerformed = "ApplicationReleaseAdded", Name = appRelease.Name.CutToMaxLength(50).UrlEncode() });
    			}
    			else
    			{
    				ViewBag.PostAction = "AddRelease";
    
    				return View("EditRelease", appRelease);
    			}
    		}
