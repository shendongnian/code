 razor
@using (Html.BeginForm("Upload", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
and check file in action
 c#
[HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if( file != null && file.Length > 0)
            {
                string file = (file.FileName).ToLower();
                try
                {
                    file.SaveAs(Server.MapPath("~/Uploads/" + file));
                }
                catch (Exception e)
                {
                    ViewBag.UploadError = "Upload file error";
                } 
               return View("Index");
            }
            else
            {
             //do something
                 return View("Index");
            }        
        }
