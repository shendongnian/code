    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product product, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return PartialView("Create", product);
            if (file != null)
            {
                
                var fileName = Path.GetFileName(file.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/Content/Uploads/ProductImages"), guid + fileName);
                file.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                string imagepath = "Content/Uploads/ProductImages/" + newpath;
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
                var nId = Guid.NewGuid().ToString();
                // Save record to database
                product.Id = nId;
                product.State = 1;
                product.ImagePath = imagepath;
                product.CreatedAt = DateTime.Now;
                db.Products.Add(product);
                await db.SaveChangesAsync();
                TempData["message"] = "ProductCreated";
                
                //return RedirectToAction("Index", product);
            }
            // after successfully uploading redirect the user
            return Json(new { success = true });
        }
