    [HttpPost]
    		[ValidateAntiForgeryToken]
    		public ActionResult Upload(int? id, IEnumerable<HttpPostedFileBase> files)
    		{
    			foreach (var file in files)
    			{
    				if (file.ContentLength > 0)
    				{
    					var fileName = id + "_" + Path.GetFileName(file.FileName);
    					var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
    					file.SaveAs(path);
    				}
    			}
    			return Json(new {name = fileName, type = "image/jpeg"});
    		}
