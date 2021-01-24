        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                string fileName = (file.FileName).ToLower();
                try
                {
                    file.SaveAs(Server.MapPath("~/Uploads/" + fileName));
                }
                catch (Exception e)
                {
                    ViewBag.UploadError = "Upload file error";
                    return View("Index");
                }
            }
            else {
                ViewBag.UploadError = "Upload file error";
                return View("Index");
            }
            return View();
        }
