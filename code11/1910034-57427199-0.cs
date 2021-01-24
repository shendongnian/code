    [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult AsynFileUpload(IEnumerable<HttpPostedFileBase> files)
            {
                int count = 0;
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        if (file != null && file.ContentLength > 0)
                        {                        
                            var path = Path.Combine(Server.MapPath("~/UploadedFiles"), file.FileName);
                            file.SaveAs(path);
                            count++;
                        }
                    }
                }
                return new JsonResult
                {
                    Data = "Successfully " + count + " file(s) uploaded"
                };
            }
